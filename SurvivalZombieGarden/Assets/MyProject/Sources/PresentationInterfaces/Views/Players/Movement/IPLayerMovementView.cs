using UnityEngine;

namespace MyProject.Sources.PresentationInterfaces.Views.Players.Movement
{
    public interface IPlayerMovementView
    {
        void Move(Vector3 direction);
        void Rotate(Quaternion look, float speed);
    }
}