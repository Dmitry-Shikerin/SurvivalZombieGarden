﻿using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MyProject.Sources.Controllers.Scenes;
using MyProject.Sources.InfrastructureInterfaces.Factories.Scenes;
using MyProject.Sources.InfrastructureInterfeces.Services;
using Unity.VisualScripting;
using StateMachine = MyProject.Sources.Infrastructure.StateMachines.SceneStateMachine.StateMachine;

namespace MyProject.Sources.Infrastructure.Services.SceneService
{
    public class SceneService : ISceneService
    {
        private readonly List<Func<string, UniTask>> _enteringHandlers = new List<Func<string, UniTask>>();
        private readonly List<Func<UniTask>> _exitingHandlers = new List<Func<UniTask>>();
        
        private readonly StateMachine _stateMachine;
        private readonly IReadOnlyDictionary<string, ISceneFactory> _sceneFactories;
        private readonly ISceneFactory _sceneFactory;

        public SceneService(IReadOnlyDictionary<string, ISceneFactory> sceneFactories)
        {
            _stateMachine = new StateMachine();
            _sceneFactories = sceneFactories ?? throw new ArgumentNullException(nameof(sceneFactories));
        }
        
        public void AddBeforeSceneChangedHandler(Func<string, UniTask> handler) =>
            _enteringHandlers.Add(handler);

        public void AddAfterSceneChangedHandler(Func<UniTask> handler) =>
            _exitingHandlers.Add(handler);

        public void RemoveEnterHandler(Func<string, UniTask> handler) =>
            _enteringHandlers.Remove(handler);

        public void RemoveExitHandler(Func<UniTask> handler) =>
            _exitingHandlers.Remove(handler);

        
        public async UniTask ChangeSceneAsync(string sceneName, object payload = null)
        {
            if (_sceneFactories.TryGetValue(sceneName, out ISceneFactory sceneFactory) == false)
                throw new InvalidOperationException(nameof(sceneName));

            foreach (Func<string, UniTask> enteringHandler in _enteringHandlers)
                await enteringHandler.Invoke(sceneName);

            IScene scene = await sceneFactory.Create(payload);
            
            _stateMachine.ChangeState(scene, payload);
            
            foreach (Func<UniTask> exitingHandler in _exitingHandlers)
                await exitingHandler.Invoke();
        }
        
        public void Update(float deltaTime)
        {
            _stateMachine.Update(deltaTime);
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
            _stateMachine.UpdateFixed(fixedDeltaTime);

        }

        public void UpdateLate(float deltaTime)
        {
            _stateMachine.UpdateLate(deltaTime);
        }
    }
}