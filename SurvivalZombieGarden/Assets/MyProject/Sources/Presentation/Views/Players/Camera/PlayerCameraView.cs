using MyProject.Sources.Controllers.Players.Camera;
using MyProject.Sources.PresentationInterfaces.Views.Players.Camera;
using UnityEngine;

namespace MyProject.Sources.Presentation.Views.Players.Camera
{
    public class PlayerCameraView : MonoBehaviour,IPlayerCameraView
    {
        [SerializeField] private Transform _targetTransform;

        //TODO перенести презентер сюда и крутить метод ротате сюда в update

        private PlayerCameraPresenter _playerCameraPresenter;
        
        public void Construct(PlayerCameraPresenter playerCameraPresenter)
        {
            _playerCameraPresenter = playerCameraPresenter;
        }

        private void Update()
        {
            _playerCameraPresenter?.Update();
        }
        
        public void Follow()
        {
            transform.position = _targetTransform.position;
        }

        public void Rotate(float angleY)
        {
            transform.rotation = Quaternion.Euler(0, angleY, 0);
        }
    }
}