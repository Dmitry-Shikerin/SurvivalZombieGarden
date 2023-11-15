using MyProject.Sources.Domain.Players.Camera;
using MyProject.Sources.Infrastructure.Factories.Player.Camera.Controllers;
using MyProject.Sources.Presentation.Views.Players.Camera;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Factories.Player.Camera.Views
{
    public class PlayerCameraViewFactory : MonoBehaviour
    {
        [SerializeField] private PlayerCameraPresenterFactory _playerCameraPresenterFactory;
        [SerializeField] private PlayerCameraView _playerCameraView;

        public PlayerCameraView Create(PlayerCamera playerCamera)
        {
            var presenter = _playerCameraPresenterFactory.Create(playerCamera, _playerCameraView);
            _playerCameraView.Construct(presenter);

            return _playerCameraView;
        }
    }
}