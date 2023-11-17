using System;
using JetBrains.Annotations;
using MyProject.Sources.Controllers.Players.Movement;
using MyProject.Sources.Domain.Players.Movement;
using MyProject.Sources.Infrastructure.Services.Inputs;
using MyProject.Sources.OldVersion.PlayerS.Domain.PlayerMovementCharacteristics;
using MyProject.Sources.Presentation.Animations;
using MyProject.Sources.PresentationInterfaces.Animations;
using MyProject.Sources.PresentationInterfaces.Views.Players;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Factories.Controllers
{
    public class PlayerMovementPresenterFactory
    {
        private InputService _inputService;
        private IPlayerAnimationView _playerAnimationView;

        public PlayerMovementPresenterFactory
        (
            InputService inputService,
            IPlayerAnimationView playerAnimationView
        )
        {
            _inputService = inputService ?? 
                            throw new ArgumentNullException(nameof(inputService));
            _playerAnimationView = playerAnimationView ?? 
                                   throw new ArgumentNullException(nameof(playerAnimationView));
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