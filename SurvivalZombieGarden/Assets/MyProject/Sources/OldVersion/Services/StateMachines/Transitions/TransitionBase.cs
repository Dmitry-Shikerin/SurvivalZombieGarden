using System;
using MyProject.Sources.OldVersion.Services.StateMachines.States;
using MyProject.Sources.OldVersion.Services.StateMachines.States.Context;

namespace MyProject.Sources.OldVersion.Services.StateMachines.Transitions
{
    public abstract class TransitionBase<TState, TContext> : ITransition<TContext> 
        where TState : StateBase 
        where TContext : IContext
    {
        public Type NextState { get; } = typeof(TState);

        public abstract bool CanTransit(TContext context);
    }
}