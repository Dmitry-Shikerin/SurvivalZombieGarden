using System;
using UnityEngine;

namespace MyProject.Scripts.PlayerServises.InputSevice
{
    public class InputService : MonoBehaviour
    {
        
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Run = "Run";

        //TODO инпут через события по типу такого?
        
        public Action<Vector2> OnMovementAxisChanged;
        public Action<float> OnRunAxisChanged;
        public Action<bool, bool> OnRotationChanged;

        private void Update()
        {
            OnMovementAxis();
            OnRunAxis();
            IsRotation();
        }
        
        public void IsRotation()
        {
            bool isLeftRotation = Input.GetKey(KeyCode.Q);
            bool isRightRotation = Input.GetKey(KeyCode.E);
            
            OnRotationChanged?.Invoke(isLeftRotation, isRightRotation);
        }

        private void OnMovementAxis()
        {
            float horizontalInput = Input.GetAxis(Horizontal);
            float verticalInput = Input.GetAxis(Vertical);
            Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
            
            OnMovementAxisChanged?.Invoke(movementDirection);
        }

        private void OnRunAxis()
        {
            float runInput = Input.GetAxis(Run);
            
            OnRunAxisChanged?.Invoke(runInput);
        }
    }
}