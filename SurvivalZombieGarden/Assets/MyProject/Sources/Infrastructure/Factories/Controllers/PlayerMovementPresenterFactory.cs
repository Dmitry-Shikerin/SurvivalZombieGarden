using System;
using MyProject.Sources.Controllers.Players.Movement;
using MyProject.Sources.Domain.Players.Movement;
using MyProject.Sources.Infrastructure.Services.Inputs;
using MyProject.Sources.OldVersion.PlayerS.Domain.PlayerMovementCharacteristics;
using MyProject.Sources.Presentation.Animations;
using MyProject.Sources.PresentationInterfaces.Views.Players;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Factories.Controllers
{
    public class PlayerMovementPresenterFactory : MonoBehaviour
    {
        [SerializeField] private PlayerMovementCharacteristic _characteristic;
        [SerializeField] private Transform _cameraTransform;

        [SerializeField] private InputService _inputService;
        [SerializeField] private PlayerAnimationView _playerAnimationView;

        private void Awake()
        {
            if (_characteristic == null)
                throw new NullReferenceException(nameof(_characteristic));
            
            if (_cameraTransform == null)
                throw new NullReferenceException(nameof(_cameraTransform));
            
            if (_inputService == null)
                throw new NullReferenceException(nameof(_inputService));
            
            if (_playerAnimationView == null)
                throw new NullReferenceException(nameof(_playerAnimationView));
        }

        public PlayerMovementPresenter Create(PlayerMovement playerMovement, IPlayerMovementView playerMovementView)
        {
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