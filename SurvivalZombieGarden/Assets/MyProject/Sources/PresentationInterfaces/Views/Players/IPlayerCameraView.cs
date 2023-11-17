using MyProject.Sources.Controllers.Players.Camera;
using UnityEngine;

namespace MyProject.Sources.PresentationInterfaces.Views.Players
{
    public interface IPlayerCameraView
    {
        public void Follow();

        public void Rotate(float angleY);

        public void Construct(PlayerCameraPresenter playerCameraPresenter);

        public void SetTransform(Transform targetTransform);
    }
}