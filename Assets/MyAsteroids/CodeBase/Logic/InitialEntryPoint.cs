using Cysharp.Threading.Tasks;
using MyAsteroids.CodeBase.Services;
using UnityEngine;

namespace MyAsteroids.CodeBase.Logic
{
    public class InitialEntryPoint
    {
        private readonly FirebaseRemoteConfig _remoteConfig;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        public InitialEntryPoint(FirebaseRemoteConfig remoteConfig, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _remoteConfig = remoteConfig;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            
            _remoteConfig.Completed += OnCompleted;
            _loadingCurtain.Show();
            
            _remoteConfig.GetRemoteConfigsAsync().Forget();
        }
        
        private void OnCompleted()
        {
            _sceneLoader.Load("Main", _loadingCurtain.Hide).Forget();
            
            _remoteConfig.Completed -= OnCompleted;
        }
    }
}