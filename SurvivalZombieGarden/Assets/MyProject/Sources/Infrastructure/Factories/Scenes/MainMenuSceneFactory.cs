using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MyProject.Sources.Controllers.Scenes;
using MyProject.Sources.Infrastructure.Services.SceneService;
using MyProject.Sources.InfrastructureInterfaces.Factories.Scenes;
using UnityEngine;

namespace MyProject.Sources.OldVersion.PlayerS.Factories.Scenes
{
    public class MainMenuSceneFactory : ISceneFactory
    {
        private readonly SceneService _sceneService;

        public MainMenuSceneFactory(SceneService sceneService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public async UniTask<IScene> Create(object payload)
        {
            Debug.Log("Сцена создана");
            
            return new MainMenuScene();
        }
    }
}