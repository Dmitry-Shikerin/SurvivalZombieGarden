using System;
using JetBrains.Annotations;
using MyProject.Sources.InfrastructureInterfaces.Factories.Scenes;
using MyProject.Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines;

namespace MyProject.Sources.Controllers.Scenes
{
    //TODO это стейты для сцены? почему он наследуется от Istate?
    public class SceneState : IState
    {
        private readonly ISceneFactory _sceneFactory;
        private IScene _scene;

        public SceneState(ISceneFactory sceneFactory)
        {
            _sceneFactory = sceneFactory ?? throw new ArgumentNullException(nameof(sceneFactory));
        }
        
        public void Update(float deltaTime) => 
            _scene?.Update(deltaTime);

        public void UpdateLate(float deltaTime) => 
            _scene?.UpdateLate(deltaTime);

        public void UpdateFixed(float fixedDeltaTime) => 
            _scene?.UpdateFixed(fixedDeltaTime);

        public void Enter(object payload)
        {
            _scene = _sceneFactory.Create(payload) ?? throw new NullReferenceException(nameof(_scene));
            _scene.Enter(payload);
        }

        public void Exit() => 
            _scene.Exit();
    }
}