using System;
using MyProject.Scripts.Services.StateMachines.States.Context;

namespace MyProject.Scripts.Services.StateMachines.Transitions
{
    public interface ITransition
    {
    }

    public interface ITransition<in T> : ITransition where T : IContext
    {
        public Type NextState { get; }

        public bool CanTransit(T context);
    }
}