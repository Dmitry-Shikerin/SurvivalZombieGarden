using System;
using JetBrains.Annotations;
using MyProject.Sources.Controllers.Players.Camera;
using MyProject.Sources.Domain.Players.Camera;
using MyProject.Sources.Infrastructure.Services.Inputs;
using MyProject.Sources.PresentationInterfaces.Views.Players;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Factories.Controllers
{
    public class PlayerCameraPresenterFactory
    {
        private InputService _inputService;

        public PlayerCameraPresenterFactory(InputService inputService)
        {
            _inputService = inputService ?? 
                            throw new ArgumentNullException(nameof(inputService));
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