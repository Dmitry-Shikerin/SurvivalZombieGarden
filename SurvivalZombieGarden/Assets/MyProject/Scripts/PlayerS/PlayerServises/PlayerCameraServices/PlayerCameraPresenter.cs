using MyProject.Scripts.PlayerServises.InputSevice;

namespace MyProject.Scripts.PlayerServises.PlayerCameraServices
{
    public class PlayerCameraPresenter
    {
        private readonly PlayerCameraModel _playerCameraModel;
        private readonly IPlayerCameraView _playerCameraView;
        private readonly InputService _inputService;

        private bool _isRightRotation;
        private bool _isLeftRotation;

        public PlayerCameraPresenter
        (
            PlayerCameraModel playerCameraModel,
            IPlayerCameraView playerCameraView,
            InputService inputService
        )
        {
            _playerCameraModel = playerCameraModel;
            _playerCameraView = playerCameraView;
            _inputService = inputService;

            _inputService.OnRotationChanged += OnRotation;
        }

        public void RotateCamera()
        {
            if (_isRightRotation)
                _playerCameraModel.SetRightRotation();

            if (_isLeftRotation)
                _playerCameraModel.SetLeftRotation();
            
            _playerCameraView.Follow();
            _playerCameraView.Rotate(_playerCameraModel.AngleY);
        }

        private void OnRotation(bool leftRotation, bool rightRotation)
        {
            _isLeftRotation = leftRotation;
            _isRightRotation = rightRotation;
        }
    }
}