using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MyProject.Sources.App.Core;
using MyProject.Sources.Controllers.Scenes;
using MyProject.Sources.Infrastructure.StateMachines.SceneStateMachine;
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

            MainMenuSceneFactory mainMenuSceneFactory = new MainMenuSceneFactory();
            GamePlaySceneFactory gamePlaySceneFactory = new GamePlaySceneFactory();

            Dictionary<string, IState> sceneStates = new Dictionary<string, IState>()
            {
                ["MainMenu"] = new SceneState(mainMenuSceneFactory),
                ["Gameplay"] = new SceneState(gamePlaySceneFactory)
            };

            StateMachine sceneStateMachine = new StateMachine(sceneStates);

            CurtainView curtainView = Object.Instantiate
                                          (Resources.Load<CurtainView>("Views/Bootstrap/CurtainView")) /*??
                                      throw new NullReferenceException(nameof(CurtainView))*/;
            //TODO что дает нам scenName
            sceneStateMachine.AddEnterHandler(sceneName => curtainView.Show());
            sceneStateMachine.AddEnterHandler(sceneName => new SceneLoaderService().Load(sceneName));
            //TODO что значат круглые скобки? чтобы не сосдавать метод?
            sceneStateMachine.AddExitHandlers(() => UniTask.CompletedTask);
            sceneStateMachine.AddExitHandlers(() => UniTask.Delay(2000));
            sceneStateMachine.AddExitHandlers(curtainView.Hide);

            appCore.Construct(sceneStateMachine);
            
            return appCore;
        }
    }
}