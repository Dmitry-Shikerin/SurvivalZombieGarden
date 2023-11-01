using UnityEngine;

namespace MyProject.Scripts.PlayerServises.PlayerMovementServices
{
    public interface IPlayerMovementView
    {
        void Move(Vector3 direction);
        void Rotate(Quaternion look, float speed);
    }
}