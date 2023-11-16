using MyProject.Sources.Controllers.Scenes;
using MyProject.Sources.InfrastructureInterfaces.Factories.Scenes;

namespace MyProject.Sources.OldVersion.PlayerS.Factories.Scenes
{
    public class GamePlaySceneFactory : ISceneFactory
    {
        public IScene Create(object payload) => 
            new GamePlayScene();
    }
}