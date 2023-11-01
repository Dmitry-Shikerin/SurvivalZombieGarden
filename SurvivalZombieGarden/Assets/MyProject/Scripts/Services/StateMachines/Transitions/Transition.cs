﻿using System;
using MyProject.Scripts.Services.StateMachines.States;
using MyProject.Scripts.Services.StateMachines.States.Context;

namespace MyProject.Scripts.Services.StateMachines.Transitions
{
    public  class Transition<TState, TContext> : ITransition<TContext>
        where TState : StateBase
        where TContext : IContext
    {
        private readonly Func<TContext, bool> _condition;

        public Transition(Func<TContext, bool> condition)
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