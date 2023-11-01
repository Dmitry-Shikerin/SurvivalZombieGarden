using UnityEngine;

namespace MyProject.Scripts.PlayerServises.PlayerMovementServices
{
    public class PlayerMovementView : MonoBehaviour,IPlayerMovementView
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _playerTransform;

        //TODO принють сюда еще одну вью на аниматорКонтроллер
        // public PlayerMovementView(CharacterController characterController, Transform playerTransform)
        // {
        //     _characterController = characterController;
        //     _playerTransform = playerTransform;
        // }

        public void Move(Vector3 direction)
        {
            _characterController.Move(direction);
        }

        public void Rotate(Quaternion look, float speed)
        {
            _playerTransform.rotation = Quaternion.RotateTowards(_playerTransform.rotation, look, speed);
        }
    }
}