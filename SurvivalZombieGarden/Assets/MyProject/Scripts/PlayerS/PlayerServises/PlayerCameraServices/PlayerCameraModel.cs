using UnityEngine;

namespace MyProject.Scripts.PlayerServises.PlayerCameraServices
{
    public class PlayerCameraModel 
    {
        private readonly Transform _cameraTransform;
        
        private float _angularSpeed = 1f;
        
        public PlayerCameraModel(Transform cameraTransform)
        {
            _cameraTransform = cameraTransform;

            AngleY = _cameraTransform.position.y;
        }
        
        public float AngleY { get; private set; }

        public void SetLeftRotation()
        {
            AngleY += _angularSpeed;
        }

        public void SetRightRotation()
        {
            AngleY -= _angularSpeed;
        }
    }
}