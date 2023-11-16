using System;
using JetBrains.Annotations;
using MyProject.Sources.Domain.Players.Camera;
using MyProject.Sources.Infrastructure.Services.Inputs;
using MyProject.Sources.PresentationInterfaces.Views.Players;

namespace MyProject.Sources.Controllers.Players.Camera
{
    public class PlayerCameraPresenter
    {
        private readonly PlayerCamera _playerCamera;
        private readonly IPlayerCameraView _playerCameraView;
        private readonly InputService _inputService;

        private bool _isRightRotation;
        private bool _isLeftRotation;

        public PlayerCameraPresenter
        (
            PlayerCamera playerCamera,
            IPlayerCameraView playerCameraView,
            InputService inputService
        )
        {
            _playerCamera = playerCamera ?? throw new ArgumentNullException(nameof(playerCamera));
            _playerCameraView = playerCameraView ?? throw new ArgumentNullException(nameof(playerCameraView));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public void Enable()
        {
            _inputService.RotationChanged += OnRotationChanged;
        }

        public void Disable()
        {
            _inputService.RotationChanged -= OnRotationChanged;
        }

        public void Update()
        {
            if (_isRightRotation)
                _playerCamera.SetRightRotation();

            if (_isLeftRotation)
                _playerCamera.SetLeftRotation();
            
            _playerCameraView.Follow();
            _playerCameraView.Rotate(_playerCamera.AngleY);
        }

        private void OnRotationChanged(bool leftRotation, bool rightRotation)
        {
            _isLeftRotation = leftRotation;
            _isRightRotation = rightRotation;
        }
    }
}