using MyProject.Sources.Controllers.Scenes;
using MyProject.Sources.InfrastructureInterfaces.Factories.Scenes;
using UnityEngine;

namespace MyProject.Sources.OldVersion.PlayerS.Factories.Scenes
{
    public class MainMenuSceneFactory : ISceneFactory
    {
        public IScene Create(object payload)
        {
            Debug.Log("Сцена создана");
            
            return new MainMenuScene();
        }
    }
}