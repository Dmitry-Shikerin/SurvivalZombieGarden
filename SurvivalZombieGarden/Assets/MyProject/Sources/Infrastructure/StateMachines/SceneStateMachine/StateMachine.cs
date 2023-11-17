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
        private IState _currentState;
        
        public void ChangeState(IState state, object payload = null)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            _currentState?.Exit();
            _currentState = state;
            _currentState?.Enter(payload);
        }

        public void Update(float deltaTime) => 
            _currentState?.Update(deltaTime);

        public void UpdateLate(float deltaTime) => 
            _currentState?.UpdateLate(deltaTime);

        public void UpdateFixed(float fixedDeltaTime) => 
            _currentState?.UpdateFixed(fixedDeltaTime);
    }
}