using System;
using MyProject.Sources.OldVersion.Services.FiniteStateMachines.States.Context;

namespace MyProject.Sources.OldVersion.Services.FiniteStateMachines.Transitions
{
    public interface IFiniteTransition
    {
    }

    public interface IFiniteTransition<in T> : IFiniteTransition where T : IFiniteContext
    {
        public Type NextState { get; }

        public bool CanTransit(T context);
    }
}