using MyProject.Scripts.PlayerServises.PlayerMovementCharacteristics;
using UnityEngine;

namespace MyProject.Scripts.PlayerServises.PlayerMovementServices
{
    public class PlayerMovementModel
    {
        private readonly PlayerMovementCharacteristic _characteristics;
        private readonly Transform _cameraPosition;

        public PlayerMovementModel
        (
            PlayerMovementCharacteristic characteristics,
            Transform cameraPosition
        )
        {
            _characteristics = characteristics;
            _cameraPosition = cameraPosition;
        }
        
        public Vector3 GetDirection(float runInput, Vector3 cameraDirection)
        {
            float speed = runInput * _characteristics.RunSpeed + _characteristics.MovementSpeed;
            Vector3 direction = cameraDirection * speed * Time.deltaTime;
            direction.y = cameraDirection.y;

            return direction;
        }

        public Vector3 GetCameraDirection(float horizontalInput, float verticalInput)
        {
            Vector3 direction = _cameraPosition.TransformDirection(horizontalInput, 0, verticalInput).normalized;
            
            direction.y -= _characteristics.Gravity * Time.deltaTime;

            return direction;
        }
        
        public bool IsIdle(float horizontalInput, float verticalInput)
        {
            return horizontalInput == 0.0f && verticalInput == 0.0f;
        }

        public Quaternion GetDirectionRotation(Vector3 direction)
        {
            return Quaternion.LookRotation(direction).normalized;
        }

        public float GetSpeedRotation()
        {
            return _characteristics.AngularSpeed * Time.deltaTime;
        }
        
        //TODO переместил этот метод из модели аниматорконтроллера
        public float GetMaxSpeed(float horizontalInput, float verticalInput, float runInput)
        {
            float maxMovementValue = Mathf.Max(Mathf.Abs(horizontalInput), Mathf.Abs(verticalInput));
            return runInput * maxMovementValue + maxMovementValue;
        }
    }
}