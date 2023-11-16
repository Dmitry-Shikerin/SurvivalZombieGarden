using System;
using JetBrains.Annotations;
using UnityEngine;

namespace MyProject.Sources.Domain.Players.Camera
{
    public class PlayerCamera 
    {
        private readonly Transform _cameraTransform;
        
        private float _angularSpeed = 1f;
        
        public PlayerCamera(Transform cameraTransform)
        {
            _cameraTransform = cameraTransform ?? throw new ArgumentNullException(nameof(cameraTransform));

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