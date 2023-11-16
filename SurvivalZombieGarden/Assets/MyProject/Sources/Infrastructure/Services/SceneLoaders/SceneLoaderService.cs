using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace MyProject.Sources.OldVersion.PlayerS.Services.SceneLoaders
{
    public class SceneLoaderService
    {
        public async UniTask Load(string sceneName) =>
            await SceneManager.LoadSceneAsync(sceneName);
    }
}