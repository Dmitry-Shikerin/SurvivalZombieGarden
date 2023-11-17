using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MyProject.Sources.Controllers.Scenes;
using MyProject.Sources.Domain.Players.Camera;
using MyProject.Sources.Domain.Players.Movement;
using MyProject.Sources.Infrastructure.Factories.Controllers;
using MyProject.Sources.Infrastructure.Factories.Views;
using MyProject.Sources.Infrastructure.Services.Inputs;
using MyProject.Sources.Infrastructure.Services.SceneService;
using MyProject.Sources.InfrastructureInterfaces.Factories.Scenes;
using MyProject.Sources.OldVersion.PlayerS.Domain.PlayerMovementCharacteristics;
using MyProject.Sources.Presentation.Animations;
using MyProject.Sources.Presentation.Views.Players;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyProject.Sources.OldVersion.PlayerS.Factories.Scenes
{
    public class GamePlaySceneFactory : ISceneFactory
    {
        private const string PlayerMovementCharacteristicsPath =
            "Configs/Players/MovementCharacteristics/Characteristics";

        private const string InputServicesPath = "Prefabs/InputServices/InputService";
        private const string PlayerCameraPath = "Prefabs/Cameras/PlayerCamera";
        private const string PlayerPrefabPath = "Prefabs/Players/Player";
        
        private readonly SceneService _sceneService;

        public GamePlaySceneFactory(SceneService sceneService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public async UniTask<IScene> Create(object payload)
        {
            #region InputService

            GameObject inputServicePrefab = Resources.Load<GameObject>(InputServicesPath);
            GameObject inputServiceGameObject = Object.Instantiate(inputServicePrefab);
            InputService inputService = inputServiceGameObject.GetComponent<InputService>();

            #endregion

            #region PlayerCamera

            GameObject playerCameraPrefab = Resources.Load<GameObject>(PlayerCameraPath);
            GameObject playerCameraGameObject = Object.Instantiate(playerCameraPrefab);
            //TODO здесь нужно запрашивать по интерфейсу? разобрал
            PlayerCameraView playerCameraView = playerCameraGameObject.GetComponent<PlayerCameraView>();

            PlayerCameraPresenterFactory playerCameraPresenterFactory =
                new PlayerCameraPresenterFactory(inputService);
            PlayerCameraViewFactory playerCameraViewFactory =
                new PlayerCameraViewFactory(playerCameraPresenterFactory, playerCameraView);
            PlayerCamera playerCamera = new PlayerCamera(playerCameraGameObject.transform);
            playerCameraViewFactory.Create(playerCamera);

            #endregion

            #region PlayerMovement

            Transform playerPrefab = Resources.Load<Transform>(PlayerPrefabPath);
            Transform player = Object.Instantiate(playerPrefab);
            PlayerAnimationView playerAnimationView = player.GetComponentInChildren<PlayerAnimationView>();
            PlayerMovementView playerMovementView = player.GetComponent<PlayerMovementView>();

            //TODO изза циклической зависимости приходится делать так, как бы пойдет но лучше фабрика
            playerCameraView.SetTransform(player);

            PlayerMovementPresenterFactory playerMovementPresenterFactory =
                new PlayerMovementPresenterFactory(inputService, playerAnimationView);
            PlayerMovementViewFactory playerMovementViewFactory =
                new PlayerMovementViewFactory(playerMovementPresenterFactory, playerMovementView);
            PlayerMovementCharacteristic playerMovementCharacteristic =
                Resources.Load<PlayerMovementCharacteristic>(PlayerMovementCharacteristicsPath);

            PlayerMovement playerMovement =
                new PlayerMovement(playerMovementCharacteristic, playerCameraGameObject.transform);
            playerMovementViewFactory.Create(playerMovement);

            #endregion


            //TODO тут нужно все регестрировать?
            return new GamePlayScene();
        }
    }
}