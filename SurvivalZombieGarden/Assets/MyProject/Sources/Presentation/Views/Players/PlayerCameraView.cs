using System;
using MyProject.Sources.Controllers.Players.Camera;
using MyProject.Sources.PresentationInterfaces.Views.Players;
using UnityEngine;

namespace MyProject.Sources.Presentation.Views.Players
{
    public class PlayerCameraView : MonoBehaviour,IPlayerCameraView
    {
        private Transform _targetTransform;

        private PlayerCameraPresenter _playerCameraPresenter;

        private void OnEnable()
        {
            _playerCameraPresenter?.Enable();
        }

        private void OnDisable()
        {
            _playerCameraPresenter?.Disable();
        }

        private void Update()
        {
            _playerCameraPresenter?.Update();
        }

        public void Construct(PlayerCameraPresenter playerCameraPresenter)
        {
            gameObject.SetActive(false);
            
            _playerCameraPresenter = playerCameraPresenter 
                                     ?? throw new ArgumentNullException(nameof(playerCameraPresenter));
            
            gameObject.SetActive(true);
        }

        public void SetTransform(Transform targetTransform)
        {
            _targetTransform = targetTransform ?? 
                               throw new ArgumentNullException(nameof(targetTransform));
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