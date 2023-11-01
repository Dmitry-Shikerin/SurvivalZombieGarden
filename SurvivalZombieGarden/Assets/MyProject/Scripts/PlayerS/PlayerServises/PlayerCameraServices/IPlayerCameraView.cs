namespace MyProject.Scripts.PlayerServises.PlayerCameraServices
{
    public interface IPlayerCameraView
    {
        public void Follow();

        public void Rotate(float angleY);
    }
}