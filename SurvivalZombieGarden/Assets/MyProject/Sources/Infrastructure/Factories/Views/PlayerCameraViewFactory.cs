using System;
using MyProject.Sources.Domain.Players.Camera;
using MyProject.Sources.Infrastructure.Factories.Controllers;
using MyProject.Sources.PresentationInterfaces.Views.Players;

namespace MyProject.Sources.Infrastructure.Factories.Views
{
    public class PlayerCameraViewFactory
    {
        private readonly PlayerCameraPresenterFactory _playerCameraPresenterFactory;
        private readonly IPlayerCameraView _playerCameraView;

        public PlayerCameraViewFactory
        (
            PlayerCameraPresenterFactory playerCameraPresenterFactory,
            IPlayerCameraView playerCameraView
        )
        {
            _playerCameraPresenterFactory = playerCameraPresenterFactory ?? 
                                            throw new ArgumentNullException(nameof(playerCameraPresenterFactory));
            _playerCameraView = playerCameraView ?? 
                                throw new ArgumentNullException(nameof(playerCameraView));
        }

        public IPlayerCameraView Create(PlayerCamera playerCamera)
        {
            var presenter = _playerCameraPresenterFactory.Create(playerCamera, _playerCameraView);
            _playerCameraView.Construct(presenter);

            return _playerCameraView;
        }
    }
}