using MyProject.Sources.Controllers.Players.Movement;
using MyProject.Sources.Domain.Players.Movement;
using MyProject.Sources.Infrastructure.Services.Input;
using MyProject.Sources.OldVersion.PlayerS.Domain.PlayerMovementCharacteristics;
using MyProject.Sources.Presentation.Views.Players.Animations;
using MyProject.Sources.PresentationInterfaces.Views.Players.Animations;
using MyProject.Sources.PresentationInterfaces.Views.Players.Movement;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Factories.Player.Movement.Controllers
{
    public class PlayerMovementPresenterFactory : MonoBehaviour
    {
        [SerializeField] private PlayerMovementCharacteristic _characteristic;
        [SerializeField] private Transform _cameraTransform;

        // private IPlayerMovementView _playerMovementView;
        private InputService _inputService;
        private IPlayerAnimationView _playerAnimationView;

        private void Start()
        {
            // _playerMovementView = FindObjectOfType<PlayerMovementView>();
            _inputService = FindObjectOfType<InputService>();
            _playerAnimationView = FindObjectOfType<PlayerAnimationView>();
        }

        public PlayerMovementPresenter Create(PlayerMovement playerMovement, IPlayerMovementView playerMovementView)
        {
            // PlayerMovementModel playerMovementModel = new PlayerMovementModel(_characteristic, _cameraTransform);
            //
            return new PlayerMovementPresenter
            (
                playerMovement,
                playerMovementView,
                _inputService,
                _playerAnimationView
            );
        }
    }
}