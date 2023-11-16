using System;
using MyProject.Sources.OldVersion.Services.FiniteStateMachines.States;
using MyProject.Sources.OldVersion.Services.FiniteStateMachines.States.Context;

namespace MyProject.Sources.OldVersion.Services.FiniteStateMachines.Transitions
{
    public abstract class FiniteTransitionBase<TState, TContext> : IFiniteTransition<TContext> 
        where TState : FiniteStateBase 
        where TContext : IFiniteContext
    {
        public Type NextState { get; } = typeof(TState);

        public abstract bool CanTransit(TContext context);
    }
}