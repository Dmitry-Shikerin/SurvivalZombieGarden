using System;
using MyProject.Sources.Controllers.Players.Camera;
using MyProject.Sources.Domain.Players.Camera;
using MyProject.Sources.Infrastructure.Services.Inputs;
using MyProject.Sources.PresentationInterfaces.Views.Players;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Factories.Controllers
{
    public class PlayerCameraPresenterFactory : MonoBehaviour
    {
        [SerializeField] private InputService _inputService;

        private void Awake()
        {
            if (_inputService == null)
                throw new NullReferenceException(nameof(_inputService));
        }

        public PlayerCameraPresenter Create(PlayerCamera playerCamera, IPlayerCameraView playerCameraView)
        {
            return new PlayerCameraPresenter
            (
                playerCamera,
                playerCameraView,
                _inputService
            );
        }
    }
}