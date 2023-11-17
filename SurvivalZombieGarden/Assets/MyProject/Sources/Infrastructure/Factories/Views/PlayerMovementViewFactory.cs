using System;
using JetBrains.Annotations;
using MyProject.Sources.Domain.Players.Movement;
using MyProject.Sources.Infrastructure.Factories.Controllers;
using MyProject.Sources.Presentation.Views.Players;
using MyProject.Sources.PresentationInterfaces.Views.Players;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Factories.Views
{
    public class PlayerMovementViewFactory
    {
        private PlayerMovementPresenterFactory _movementPresenterFactory;
        private IPlayerMovementView _playerMovementView;

        public PlayerMovementViewFactory
        (
            PlayerMovementPresenterFactory movementPresenterFactory,
            IPlayerMovementView playerMovementView
        )
        {
            _movementPresenterFactory = movementPresenterFactory ?? 
                                        throw new ArgumentNullException(nameof(movementPresenterFactory));
            _playerMovementView = playerMovementView ?? 
                                  throw new ArgumentNullException(nameof(playerMovementView));
        }

        //TODO для чего здесь возвращаемое значение
        public IPlayerMovementView Create(PlayerMovement playerMovement)
        {
            var presenter = _movementPresenterFactory.Create(playerMovement, _playerMovementView);
            _playerMovementView.Construct(presenter);

            return _playerMovementView;
        }
    }
}