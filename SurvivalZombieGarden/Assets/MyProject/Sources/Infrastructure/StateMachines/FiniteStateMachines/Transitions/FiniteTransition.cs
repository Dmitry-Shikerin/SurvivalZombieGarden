using System;
using MyProject.Sources.OldVersion.Services.FiniteStateMachines.States;
using MyProject.Sources.OldVersion.Services.FiniteStateMachines.States.Context;

namespace MyProject.Sources.OldVersion.Services.FiniteStateMachines.Transitions
{
    public  class FiniteTransition<TState, TContext> : IFiniteTransition<TContext>
        where TState : FiniteStateBase
        where TContext : IFiniteContext
    {
        private readonly Func<TContext, bool> _condition;

        public FiniteTransition(Func<TContext, bool> condition)
        {
            _condition = condition;
        }

        public Type NextState { get; } = typeof(TState);

        public bool CanTransit(TContext context)
        {
            return _condition.Invoke(context);
        }
    }
}