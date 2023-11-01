using MyProject.Scripts.PlayerServises.InputSevice;
using UnityEngine;

namespace MyProject.Scripts.PlayerServises.PlayerMovementServices
{
    public class PlayerMovementPresenter
    {
        private readonly PlayerMovementModel _playerMovementModel;
        private readonly IPlayerMovementView _playerMovementView;
        private readonly Transform _playerTransform;
        private readonly InputService _inputService;
        private readonly IPlayerAnimationControllerView _playerAnimationControllerView;

        private Vector2 _moveInput;
        private float _runInput;

        public PlayerMovementPresenter
        (
            PlayerMovementModel playerMovementModel,
            IPlayerMovementView playerMovementView,
            Transform playerTransform,
            InputService inputService,
            IPlayerAnimationControllerView playerAnimationControllerView
        )
        {
            _playerMovementModel = playerMovementModel;
            _playerMovementView = playerMovementView;
            //TODO вью монобех и нанееНакидвать трансформ
            //TODO перенести воввью
            _playerTransform = playerTransform;
            _inputService = inputService;
            _playerAnimationControllerView = playerAnimationControllerView;

            //TODO подписываться Здесь? и где отписываться?
            _inputService.OnMovementAxisChanged += SetMovementAxis;
            _inputService.OnRunAxisChanged += SetRunAxis;
        }
        
        public void Move()
        {
            //TODO сделать Vector2 вместо флотов
            
            Vector3 cameraDirection = _playerMovementModel.GetCameraDirection
                (_moveInput.x, _moveInput.y);

            Vector3 direction = _playerMovementModel.GetDirection(_runInput, cameraDirection);

            float animationsSpeed = _playerMovementModel.GetMaxSpeed
                (_moveInput.x, _moveInput.y, _runInput);
            
            _playerAnimationControllerView.PlayMovementAnimation(animationsSpeed);
            _playerMovementView.Move(direction);

            if (_playerMovementModel.IsIdle(_moveInput.x, _moveInput.y))
                return;
            
            Quaternion look = _playerMovementModel.GetDirectionRotation(cameraDirection);
            
            float speedRotation = _playerMovementModel.GetSpeedRotation();

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