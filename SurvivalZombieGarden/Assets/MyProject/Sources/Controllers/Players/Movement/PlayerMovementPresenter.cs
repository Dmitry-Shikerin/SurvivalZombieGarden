using System;
using JetBrains.Annotations;
using MyProject.Sources.Domain.Players.Movement;
using MyProject.Sources.Infrastructure.Services.Inputs;
using MyProject.Sources.PresentationInterfaces.Animations;
using MyProject.Sources.PresentationInterfaces.Views.Players;
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
            IPlayerAnimationView playerAnimationView
        )
        {
            _playerMovement = playerMovement ?? throw new ArgumentNullException(nameof(playerMovement));
            _playerMovementView = playerMovementView ?? throw new ArgumentNullException(nameof(playerMovementView));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _playerAnimationView = playerAnimationView ?? throw new ArgumentNullException(nameof(playerAnimationView));
        }

        public void Enable()
        {
            _inputService.MovementAxisChanged += SetMovementAxis;
            _inputService.RunAxisChanged += SetRunAxis;
        }
        
        public void Disable()
        {
            _inputService.MovementAxisChanged -= SetMovementAxis;
            _inputService.RunAxisChanged -= SetRunAxis;
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