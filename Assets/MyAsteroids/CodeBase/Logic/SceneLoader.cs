using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace MyAsteroids.CodeBase.Logic
{
    public class SceneLoader
    {
        public void LoadMainScene(UnityAction onLoaded = null)
        {
            Load("Main", onLoaded).Forget();
        }
        
        private async UniTask Load(string name, UnityAction onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                return;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            await UniTask.WaitUntil(() => waitNextScene.isDone);

            onLoaded?.Invoke();
        }
    }
}