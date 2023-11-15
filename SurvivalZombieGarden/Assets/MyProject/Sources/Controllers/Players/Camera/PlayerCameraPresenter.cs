using MyProject.Sources.Domain.Players.Camera;
using MyProject.Sources.Infrastructure.Services.Input;
using MyProject.Sources.PresentationInterfaces.Views.Players.Camera;

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
            _playerCamera = playerCamera;
            _playerCameraView = playerCameraView;
            _inputService = inputService;
            
            //TODO здесть подписки быть не дорлжно, посмотреть гист леши
            _inputService.RotationChanged += OnRotationChanged;
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