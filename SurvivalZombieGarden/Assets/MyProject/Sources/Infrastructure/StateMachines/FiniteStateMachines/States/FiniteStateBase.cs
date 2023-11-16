using System;
using System.Collections.Generic;
using MyProject.Sources.OldVersion.Services.FiniteStateMachines.States.Context;
using MyProject.Sources.OldVersion.Services.FiniteStateMachines.Transitions;

namespace MyProject.Sources.OldVersion.Services.FiniteStateMachines.States
{
    public abstract class FiniteStateBase
    {
        private readonly IEnumerable<IFiniteTransition> _transitions;

        protected FiniteStateBase(IEnumerable<IFiniteTransition> transitions)
        {
            _transitions = transitions;
        }

        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {

        }

        public bool TryGetNextState<T>(T context, out Type state) where T : IFiniteContext
        {
            foreach (IFiniteTransition transition in _transitions)
            {
                if (transition is IFiniteTransition<T> concreteTransition)
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