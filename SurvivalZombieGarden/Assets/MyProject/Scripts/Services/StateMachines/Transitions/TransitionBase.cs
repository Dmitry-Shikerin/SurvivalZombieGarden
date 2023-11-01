using System;
using MyProject.Scripts.Services.StateMachines.States;
using MyProject.Scripts.Services.StateMachines.States.Context;

namespace MyProject.Scripts.Services.StateMachines.Transitions
{
    public abstract class TransitionBase<TState, TContext> : ITransition<TContext> 
        where TState : StateBase 
        where TContext : IContext
    {
        public Type NextState { get; } = typeof(TState);

        public abstract bool CanTransit(TContext context);
    }
}