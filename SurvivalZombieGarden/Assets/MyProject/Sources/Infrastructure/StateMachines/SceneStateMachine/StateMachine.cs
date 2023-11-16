using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MyProject.Sources.InfrastructureInterfeces.Services;
using Unity.VisualScripting;
using IState = MyProject.Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines.IState;

namespace MyProject.Sources.Infrastructure.StateMachines.SceneStateMachine
{
    public class StateMachine : IUpdatable, ILateUpdatable, IFixedUpdatable
    {
        //TODO для чего здесь string имя сцены?
        private readonly List<Func<string, UniTask>> _enteringHandlers = new List<Func<string, UniTask>>();
        private readonly List<Func<UniTask>> _exitingHandlers = new List<Func<UniTask>>();

        private readonly Dictionary<string, IState> _states;

        private IState _currentState;

        public StateMachine(Dictionary<string, IState> states)
        {
            _states = states ?? throw new ArgumentNullException(nameof(states));
        }

        //TODO Это добавление обработчиков асинка которые отработают при загрузке сцены?
        public void AddEnterHandler(Func<string, UniTask> handler) =>
            _enteringHandlers.Add(handler);

        public void AddExitHandlers(Func<UniTask> handler) =>
            _exitingHandlers.Add(handler);

        public void RemoveEnterHandler(Func<string, UniTask> handler) =>
            _enteringHandlers.Remove(handler);

        public void RemoveExitHandler(Func<UniTask> handler) =>
            _exitingHandlers.Remove(handler);

        public async UniTask ChangeStateAsync(string stateName, object payload = null)
        {
            if (HasState(stateName) == false)
                throw new InvalidOperationException(nameof(stateName));

            //TODO что происходит вот здесь
            foreach (Func<string, UniTask> enteringHandler in _enteringHandlers)
                await enteringHandler.Invoke(stateName);

            _currentState?.Exit();
            _currentState = _states[stateName];
            _currentState?.Enter(payload);

            //TODO это включение обработчиков на выходе сцены?
            //TODO await это инструкция по типу yeild retern?
            foreach (Func<UniTask> exitingHandler in _exitingHandlers)
                await exitingHandler.Invoke();
        }

        public void Update(float deltaTime) => 
            _currentState?.Update(deltaTime);

        public void UpdateLate(float deltaTime) => 
            _currentState?.UpdateLate(deltaTime);

        public void UpdateFixed(float fixedDeltaTime) => 
            _currentState?.UpdateFixed(fixedDeltaTime);

        private bool HasState(string stateName) =>
            _states.ContainsKey(stateName);
    }
}