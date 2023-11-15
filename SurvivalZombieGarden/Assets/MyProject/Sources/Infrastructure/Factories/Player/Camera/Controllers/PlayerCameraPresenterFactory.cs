using MyProject.Sources.Controllers.Players.Camera;
using MyProject.Sources.Domain.Players.Camera;
using MyProject.Sources.Infrastructure.Services.Input;
using MyProject.Sources.PresentationInterfaces.Views.Players.Camera;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Factories.Player.Camera.Controllers
{
    public class PlayerCameraPresenterFactory : MonoBehaviour
    {
        [SerializeField] private InputService _inputService;

        //TODO убрать его отсюда
        private void OnValidate()
        {
            //TODO Почитать документацию об этом методе 
            //TODO Сделать проверки на вхождине из филдов по типу конструктора
        }

        public PlayerCameraPresenter Create(PlayerCamera playerCamera, IPlayerCameraView playerCameraView)
        {
            //TODO у модели не должно в названии быть слова модель

            return new PlayerCameraPresenter
            (
                playerCamera,
                playerCameraView,
                _inputService
            );
        }
    }
}