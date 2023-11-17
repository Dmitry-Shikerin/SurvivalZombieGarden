using MyProject.Sources.Controllers.Players.Movement;
using UnityEngine;

namespace MyProject.Sources.PresentationInterfaces.Views.Players
{
    public interface IPlayerMovementView
    {
        void Move(Vector3 direction);
        void Rotate(Quaternion look, float speed);
        void Construct(PlayerMovementPresenter playerMovementPresenter);
    }
}