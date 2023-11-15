using System;
using MyProject.Sources.OldVersion.Services.StateMachines.States.Context;

namespace MyProject.Sources.OldVersion.Services.StateMachines.Transitions
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