using Cysharp.Threading.Tasks;
using MyProject.Sources.Controllers.Scenes;

namespace MyProject.Sources.InfrastructureInterfaces.Factories.Scenes
{
    public interface ISceneFactory
    {
        //TODO пайлоад заменится на зависимости?
         UniTask<IScene> Create(object payload);
    }
}