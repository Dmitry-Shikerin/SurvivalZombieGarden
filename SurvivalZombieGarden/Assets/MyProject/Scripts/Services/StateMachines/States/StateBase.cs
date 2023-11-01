﻿using System;
using System.Collections.Generic;
using MyProject.Scripts.Services.StateMachines.States.Context;
using MyProject.Scripts.Services.StateMachines.Transitions;

namespace MyProject.Scripts.Services.StateMachines.States
{
    public abstract class StateBase
    {
        private readonly IEnumerable<ITransition> _transitions;

        protected StateBase(IEnumerable<ITransition> transitions)
        {
            _transitions = transitions;
        }

        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {

        }

        public bool TryGetNextState<T>(T context, out Type state) where T : IContext
        {
            foreach (ITransition transition in _transitions)
            {
                if (transition is ITransition<T> concreteTransition)
                {
                    if (concreteTransition.CanTransit(context))
                    {
                        state = concreteTransition.NextState;

                        return true;
                    }
                }
            }

            state = null;

            return false;
        }
    }
}