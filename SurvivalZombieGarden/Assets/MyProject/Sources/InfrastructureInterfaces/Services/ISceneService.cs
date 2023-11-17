using Cysharp.Threading.Tasks;

namespace MyProject.Sources.InfrastructureInterfeces.Services
{
    public interface ISceneService : IUpdatable, IFixedUpdatable, ILateUpdatable
    {
        UniTask ChangeSceneAsync(string sceneName, object payload);
    }
}