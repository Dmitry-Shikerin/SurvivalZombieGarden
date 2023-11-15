using MyProject.Sources.Controllers.Players.Movement;
using MyProject.Sources.PresentationInterfaces.Views.Players.Movement;
using UnityEngine;

namespace MyProject.Sources.Presentation.Views.Players.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementView : MonoBehaviour, IPlayerMovementView
    {
        private CharacterController _characterController;

        private PlayerMovementPresenter _movementPresenter;
        
        public void Construct(PlayerMovementPresenter movementPresenter)
        {
            _movementPresenter = movementPresenter;
        }
        
        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _movementPresenter.Update();
        }

        public void Move(Vector3 direction)
        {
            _characterController.Move(direction);
        }

        public void Rotate(Quaternion look, float speed)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, look, speed);
        }
    }
}