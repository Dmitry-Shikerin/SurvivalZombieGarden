using System;
using System.Collections.Generic;
using MyProject.Sources.OldVersion.Services.FiniteStateMachines.States;
using MyProject.Sources.OldVersion.Services.FiniteStateMachines.States.Context;

namespace MyProject.Sources.OldVersion.Services.FiniteStateMachines
{
    public class FiniteStateMachine
    {
        private Dictionary<Type, FiniteStateBase> _states;

        private FiniteStateBase _current;

        public FiniteStateMachine(Dictionary<Type, FiniteStateBase> states)
        {
            _states = states;
        }
    
        public void Update<T>(T context) where T : IFiniteContext
        {
            if (_current.TryGetNextState(context, out Type state) == false)
            {
                return;
            }
        
            MoveNextState(state);
        }

        private void MoveNextState(Type nextState)
        {
            if (_states.ContainsKey(nextState) == false)
                throw new KeyNotFoundException("Состояние не найдено в Dictionary : " + nextState.Name);
        
            _current?.Exit();
            _current = _states[nextState];
            _current.Enter();
        }

        public void Start<T>() where T : FiniteStateBase
        {
            MoveNextState(typeof(T));
        }
    }}