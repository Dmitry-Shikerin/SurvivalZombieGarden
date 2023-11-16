namespace MyProject.Sources.PresentationInterfaces.Views.Players
{
    public interface IPlayerCameraView
    {
        public void Follow();

        public void Rotate(float angleY);
    }
}