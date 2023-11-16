using System;
using JetBrains.Annotations;
using MyProject.Sources.OldVersion.PlayerS.Domain.PlayerMovementCharacteristics;
using UnityEngine;

namespace MyProject.Sources.Domain.Players.Movement
{
    public class PlayerMovement
    {
        private readonly PlayerMovementCharacteristic _characteristics;
        private readonly Transform _cameraPosition;

        public PlayerMovement
        (
            PlayerMovementCharacteristic characteristics,
            Transform cameraPosition
        )
        {
            _characteristics = characteristics ?? throw new ArgumentNullException(nameof(characteristics));
            _cameraPosition = cameraPosition ?? throw new ArgumentNullException(nameof(cameraPosition));
        }
        
        public Vector3 GetDirection(float runInput, Vector3 cameraDirection)
        {
            float speed = runInput * _characteristics.RunSpeed + _characteristics.MovementSpeed;
            Vector3 direction = cameraDirection * speed * Time.deltaTime;
            direction.y = cameraDirection.y;

            return direction;
        }

        public Vector3 GetCameraDirection(Vector2 moveInput)
        {
            Vector3 direction = _cameraPosition.TransformDirection(moveInput.x, 0, moveInput.y).normalized;
            
            direction.y -= _characteristics.Gravity * Time.deltaTime;

            return direction;
        }
        
        public bool IsIdle(Vector2 moveInput)
        {
            return moveInput.x == 0.0f && moveInput.y == 0.0f;
        }

        public Quaternion GetDirectionRotation(Vector3 direction)
        {
            return Quaternion.LookRotation(direction).normalized;
        }

        public float GetSpeedRotation()
        {
            return _characteristics.AngularSpeed * Time.deltaTime;
        }
        
        public float GetMaxSpeed(Vector2 moveInput, float runInput)
        {
            float maxMovementValue = Mathf.Max(Mathf.Abs(moveInput.x), Mathf.Abs(moveInput.y));
            return runInput * maxMovementValue + maxMovementValue;
        }
    }
}