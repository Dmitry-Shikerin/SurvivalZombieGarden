using MyProject.Sources.Controllers.Scenes;

namespace MyProject.Sources.InfrastructureInterfaces.Factories.Scenes
{
    public interface ISceneFactory
    {
        //TODO пайлоад заменится на зависимости?
        IScene Create(object payload);
    }
}