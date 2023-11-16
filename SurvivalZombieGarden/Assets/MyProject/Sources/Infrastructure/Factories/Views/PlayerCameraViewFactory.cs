using System;
using MyProject.Sources.Domain.Players.Camera;
using MyProject.Sources.Infrastructure.Factories.Controllers;
using MyProject.Sources.Presentation.Views.Players;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Factories.Views
{
    public class PlayerCameraViewFactory : MonoBehaviour
    {
        [SerializeField] private PlayerCameraPresenterFactory _playerCameraPresenterFactory;
        [SerializeField] private PlayerCameraView _playerCameraView;

        private void Awake()
        {
            if (_playerCameraPresenterFactory == null)
                throw new NullReferenceException(nameof(_playerCameraPresenterFactory));

            if (_playerCameraView == null)
                throw new NullReferenceException(nameof(_playerCameraView));
        }

        public PlayerCameraView Create(PlayerCamera playerCamera)
        {
            var presenter = _playerCameraPresenterFactory.Create(playerCamera, _playerCameraView);
            _playerCameraView.Construct(presenter);

            return _playerCameraView;
        }
    }
}