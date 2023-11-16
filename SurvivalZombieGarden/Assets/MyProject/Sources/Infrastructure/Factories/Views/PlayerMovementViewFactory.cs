using System;
using MyProject.Sources.Domain.Players.Movement;
using MyProject.Sources.Infrastructure.Factories.Controllers;
using MyProject.Sources.Presentation.Views.Players;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Factories.Views
{
    public class PlayerMovementViewFactory : MonoBehaviour
    {
        [SerializeField] private PlayerMovementPresenterFactory _movementPresenterFactory;
        [SerializeField] private PlayerMovementView _playerMovementView;

        private void Awake()
        {
            if (_movementPresenterFactory == null)
                throw new NullReferenceException(nameof(_movementPresenterFactory));
            
            if (_playerMovementView == null)
                throw new NullReferenceException(nameof(_playerMovementView));
        }

        public PlayerMovementView Create(PlayerMovement playerMovement)
        {
            var presenter = _movementPresenterFactory.Create(playerMovement, _playerMovementView);
            _playerMovementView.Construct(presenter);

            return _playerMovementView;
        }
    }
}
