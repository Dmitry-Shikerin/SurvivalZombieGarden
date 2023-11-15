using MyProject.Sources.Domain.Players.Camera;
using MyProject.Sources.Domain.Players.Movement;
using MyProject.Sources.Infrastructure.Factories.Player.Camera.Views;
using MyProject.Sources.Infrastructure.Factories.Player.Movement.Views;
using MyProject.Sources.OldVersion.PlayerS.Domain.PlayerMovementCharacteristics;
using MyProject.Sources.Presentation.Views.Players.Camera;
using MyProject.Sources.Presentation.Views.Players.Movement;
using UnityEngine;

namespace MyProject.Sources.OldVersion.PlayerS
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerCameraViewFactory _playerCameraViewFactory;
        [SerializeField] private Transform _cameraTransform;

        [SerializeField] private PlayerMovementViewFactory _movementViewFactory;
        [SerializeField] private PlayerMovementCharacteristic _movementCharacteristic;

        void Start()
        {
            PlayerCamera playerCamera = new PlayerCamera(_cameraTransform);
            PlayerCameraView playerCameraView = _playerCameraViewFactory.Create(playerCamera);

            PlayerMovement playerMovement = new PlayerMovement(_movementCharacteristic, _cameraTransform);
            PlayerMovementView playerMovementView = _movementViewFactory.Create(playerMovement);
        }
    }
}