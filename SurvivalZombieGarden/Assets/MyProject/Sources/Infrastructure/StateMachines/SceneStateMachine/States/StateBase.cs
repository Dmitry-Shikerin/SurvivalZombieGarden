using MyProject.Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines;

namespace MyProject.Sources.Infrastructure.StateMachines.SceneStateMachine.States
{
    public abstract class StateBase : IState
    {
        public virtual void Update(float deltaTime)
        {
        }

        public virtual void UpdateLate(float deltaTime)
        {
        }

        public virtual void UpdateFixed(float fixedDeltaTime)
        {
        }

        public abstract void Enter(object payload);

        public abstract void Exit();
    }
}