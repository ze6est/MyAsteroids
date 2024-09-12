using MyAsteroids.CodeBase.Services.RemoteConfig;
using Zenject;

namespace MyAsteroids.CodeBase.Logic
{
    public class EntryPoint : IInitializable
    {
        private readonly IRemoteConfig _remoteConfig;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        public EntryPoint(IRemoteConfig remoteConfig, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _remoteConfig = remoteConfig;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }
        
        public async void Initialize()
        {
            _loadingCurtain.Show();
            
            await _remoteConfig.GetRemoteConfigsAsync();
            
            _sceneLoader.LoadMainScene(_loadingCurtain.Hide);
        }
    }
}