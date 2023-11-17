using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MyProject.Sources.App.Core;
using MyProject.Sources.Controllers.Scenes;
using MyProject.Sources.Infrastructure.Services.SceneService;
using MyProject.Sources.Infrastructure.StateMachines.SceneStateMachine;
using MyProject.Sources.InfrastructureInterfaces.Factories.Scenes;
using MyProject.Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines;
using MyProject.Sources.OldVersion.PlayerS.Factories.Scenes;
using MyProject.Sources.OldVersion.PlayerS.Services.SceneLoaders;
using MyProject.Sources.PresentationInterfaces.Views.Bootstrap;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyProject.Sources.OldVersion.PlayerS.Factories.App
{
    public class AppCoreFactory
    {
        public AppCore Create()
        {
            AppCore appCore = new GameObject(nameof(AppCore))
                .AddComponent<AppCore>();
            
            CurtainView curtainView = Object.Instantiate
                                          (Resources.Load<CurtainView>("Views/Bootstrap/CurtainView")) ??
                                      throw new NullReferenceException(nameof(CurtainView));

            Dictionary<string, ISceneFactory> sceneStates = new Dictionary<string, ISceneFactory>();
            SceneService sceneService = new SceneService(sceneStates);
            
            sceneStates["MainMenu"] = new MainMenuSceneFactory(sceneService);
            sceneStates["Gameplay"] = new GamePlaySceneFactory(sceneService);
            
            //TODO почитать про UniTask'и
            sceneService.AddBeforeSceneChangedHandler(sceneName => curtainView.Show());
            sceneService.AddBeforeSceneChangedHandler(sceneName => new SceneLoaderService().Load(sceneName));
            // sceneService.AddAfterSceneChangedHandler(() => UniTask.CompletedTask);
            sceneService.AddAfterSceneChangedHandler(() => UniTask.Delay(2000));
            sceneService.AddAfterSceneChangedHandler(curtainView.Hide);

            appCore.Construct(sceneService);

            
            return appCore;
        }
    }
}