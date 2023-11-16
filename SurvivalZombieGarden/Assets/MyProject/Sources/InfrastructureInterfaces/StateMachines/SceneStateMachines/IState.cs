using MyProject.Sources.InfrastructureInterfeces.Services;
using MyProject.Sources.InfrastructureInterfeces.StateMachines.SceneStateMachines;

namespace MyProject.Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines
{
    public interface IState : IUpdatable, ILateUpdatable, IFixedUpdatable, IEnterable, IExitable
    {
        
    }
}