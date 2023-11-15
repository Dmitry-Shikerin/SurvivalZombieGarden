using MyProject.Sources.Domain.Players.Movement;
using MyProject.Sources.Infrastructure.Services.Input;
using MyProject.Sources.PresentationInterfaces.Views.Players.Animations;
using MyProject.Sources.PresentationInterfaces.Views.Players.Movement;
using UnityEngine;

namespace MyProject.Sources.Controllers.Players.Movement
{
    public class PlayerMovementPresenter
    {
        private readonly PlayerMovement _playerMovement;
        private readonly IPlayerMovementView _playerMovementView;
        private readonly Transform _playerTransform;
        private readonly InputService _inputService;
        private readonly IPlayerAnimationView _playerAnimationView;

        private Vector2 _moveInput;
        private float _runInput;

        public PlayerMovementPresenter
        (
            PlayerMovement playerMovement,
            IPlayerMovementView playerMovementView,
            InputService inputService,
            //TODO убрать слово контрольллер и вью
            IPlayerAnimationView playerAnimationView
        )
        {
            _playerMovement = playerMovement;
            _playerMovementView = playerMovementView;
            _inputService = inputService;
            _playerAnimationView = playerAnimationView;

            //TODO подписываться Здесь? и где отписываться?
            _inputService.MovementAxisChanged += SetMovementAxis;
            _inputService.RunAxisChanged += SetRunAxis;
        }
        
        public void Update()
        {
            Vector3 cameraDirection = _playerMovement.GetCameraDirection
                (_moveInput);

            Vector3 direction = _playerMovement.GetDirection(_runInput, cameraDirection);

            float animationsSpeed = _playerMovement.GetMaxSpeed
                (_moveInput, _runInput);
            
            _playerAnimationView.PlayMovementAnimation(animationsSpeed);
            _playerMovementView.Move(direction);

            if (_playerMovement.IsIdle(_moveInput))
                return;
            
            Quaternion look = _playerMovement.GetDirectionRotation(cameraDirection);
            
            float speedRotation = _playerMovement.GetSpeedRotation();

            _playerMovementView.Rotate(look, speedRotation);
        }

        private void SetMovementAxis(Vector2 moveDirection)
        {
            _moveInput = moveDirection;
        }

        private void SetRunAxis(float runInput)
        {
            _runInput = runInput;
        }
    }
}