using MyAsteroids.CodeBase.Services.Ads;
using MyAsteroids.CodeBase.Services.RemoteConfig;
using Zenject;

namespace MyAsteroids.CodeBase.Logic
{
    public class EntryPoint : IInitializable
    {
        private readonly IRemoteConfig _remoteConfig;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly AdsInitializer _adsInitializer;

        public EntryPoint(IRemoteConfig remoteConfig, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, AdsInitializer adsInitializer)
        {
            _remoteConfig = remoteConfig;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _adsInitializer = adsInitializer;
        }
        
        public async void Initialize()
        {
            _loadingCurtain.Show();
            
            await _remoteConfig.GetRemoteConfigsAsync();
            
            _adsInitializer.InitializeAds();
            _sceneLoader.LoadMainScene(_loadingCurtain.Hide);
        }
    }
}