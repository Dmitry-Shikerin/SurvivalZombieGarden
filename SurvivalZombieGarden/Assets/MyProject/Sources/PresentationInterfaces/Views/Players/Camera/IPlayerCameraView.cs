namespace MyProject.Sources.PresentationInterfaces.Views.Players.Camera
{
    public interface IPlayerCameraView
    {
        public void Follow();

        public void Rotate(float angleY);
    }
}