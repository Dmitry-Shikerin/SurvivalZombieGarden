using System;
using MyProject.Sources.Controllers.Players.Movement;
using MyProject.Sources.PresentationInterfaces.Views.Players;
using UnityEngine;

namespace MyProject.Sources.Presentation.Views.Players
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementView : MonoBehaviour, IPlayerMovementView
    {
        private CharacterController _characterController;

        private PlayerMovementPresenter _movementPresenter;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>() ?? 
                                   throw new NullReferenceException(nameof(CharacterController));
        }

        private void OnEnable()
        {
            _movementPresenter?.Enable();
        }

        private void OnDisable()
        {
            _movementPresenter?.Disable();
        }

        private void Update()
        {
            _movementPresenter.Update();
        }

        public void Construct(PlayerMovementPresenter movementPresenter)
        {
            gameObject.SetActive(false);
            
            _movementPresenter = movementPresenter ?? 
                                 throw new ArgumentNullException(nameof(movementPresenter));
            
            gameObject.SetActive(true);
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