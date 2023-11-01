using UnityEngine;

namespace MyProject.Scripts.PlayerServises.PlayerCameraServices
{
    public class PlayerCameraView : MonoBehaviour,IPlayerCameraView
    {
        // [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Transform _targetTransform;

        // public PlayerCameraView(Transform cameraTransform, Transform targetTransform)
        // {
        //     _cameraTransform = cameraTransform;
        //     _targetTransform = targetTransform;
        // }

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