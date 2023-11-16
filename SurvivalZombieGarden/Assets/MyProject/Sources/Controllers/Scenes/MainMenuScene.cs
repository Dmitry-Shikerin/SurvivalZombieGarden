using UnityEngine;

namespace MyProject.Sources.Controllers.Scenes
{
    public class MainMenuScene : IScene
    {
        public void Update(float deltaTime)
        {
            
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }

        public void Enter(object payload)
        {
            Debug.Log("Сцена загружена");
        }

        public void Exit()
        {
        }
    }
}