using MyProject.Sources.Domain.Players.Movement;
using MyProject.Sources.Infrastructure.Factories.Player.Movement.Controllers;
using MyProject.Sources.Presentation.Views.Players.Movement;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Factories.Player.Movement.Views
{
    public class PlayerMovementViewFactory : MonoBehaviour
    {
        [SerializeField] private PlayerMovementPresenterFactory _movementPresenterFactory;
        [SerializeField] private PlayerMovementView _playerMovementView;

        public PlayerMovementView Create(PlayerMovement playerMovement)
        {
            var presenter = _movementPresenterFactory.Create(playerMovement, _playerMovementView);
            _playerMovementView.Construct(presenter);

            return _playerMovementView;
        }
    }
}
