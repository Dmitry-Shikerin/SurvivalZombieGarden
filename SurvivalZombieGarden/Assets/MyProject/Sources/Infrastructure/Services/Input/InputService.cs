using System;
using UnityEngine;

namespace MyProject.Sources.Infrastructure.Services.Input
{
    public class InputService : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Run = "Run";

        public Action<Vector2> MovementAxisChanged;
        public Action<float> RunAxisChanged;
        public Action<bool, bool> RotationChanged;

        private void Update()
        {
            UpdateMovementAxis();
            UpdateRunAxis();
            UpdateRotation();
        }

        private void UpdateRotation()
        {
            bool isLeftRotation = UnityEngine.Input.GetKey(KeyCode.Q);
            bool isRightRotation = UnityEngine.Input.GetKey(KeyCode.E);
            
            RotationChanged?.Invoke(isLeftRotation, isRightRotation);
        }

        private void UpdateMovementAxis()
        {
            float horizontalInput = UnityEngine.Input.GetAxis(Horizontal);
            float verticalInput = UnityEngine.Input.GetAxis(Vertical);
            Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
            
            MovementAxisChanged?.Invoke(movementDirection);
        }

        private void UpdateRunAxis()
        {
            float runInput = UnityEngine.Input.GetAxis(Run);
            
            RunAxisChanged?.Invoke(runInput);
        }
    }
}