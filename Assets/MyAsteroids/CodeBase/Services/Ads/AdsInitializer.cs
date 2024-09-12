using MyAsteroids.CodeBase.Data;
using UnityEngine;
using UnityEngine.Advertisements;
using Zenject;

namespace MyAsteroids.CodeBase.Services.Ads
{
    public class AdsInitializer : IUnityAdsInitializationListener, IInitializable
    {
        private readonly GameData _data;
        private readonly InterstitialAds _interstitialAds;

        private string _androidGameId;
        private string _iOSGameId;
        private bool _testMode;

        private string _gameId;

        public AdsInitializer(GameData data, InterstitialAds interstitialAds)
        {
            _data = data;
            _interstitialAds = interstitialAds;
        }

        public void Initialize()
        {
            _androidGameId = _data.AdsData.AndroidGameId;
            _iOSGameId = _data.AdsData.IOSGameId;
            _testMode = _data.AdsData.TestMode;
        }

        public void InitializeAds()
        {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
            _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                Advertisement.Initialize(_gameId, _testMode, this);
            }
        }

        public void OnInitializationComplete()
        {
            _interstitialAds.LoadAd();
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message) => 
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}