using MyAsteroids.CodeBase.Data;
using UnityEngine;
using UnityEngine.Advertisements;
using Zenject;

namespace MyAsteroids.CodeBase.Services.Ads
{
    public class InterstitialAds : IUnityAdsLoadListener, IUnityAdsShowListener, IInitializable
    {
        private readonly GameData _data;
        
        private string _androidAdUnitId;
        private string _iOsAdUnitId;
        private string _adUnitId;

        public InterstitialAds(GameData data) => 
            _data = data;

        public void Initialize()
        {
            _androidAdUnitId = _data.AdsData.AndroidAdUnitId;
            _iOsAdUnitId = _data.AdsData.IOsAdUnitId;
            
            _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? _iOsAdUnitId
                : _androidAdUnitId;
        }
        
        public void LoadAd()
        {
            Debug.Log("Loading Ad: " + _adUnitId);
            Advertisement.Load(_adUnitId, this);
        }
        
        public void ShowAd()
        {
            Debug.Log("Showing Ad: " + _adUnitId);
            Advertisement.Show(_adUnitId, this);
        }
        
        public void OnUnityAdsAdLoaded(string adUnitId){}

        public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message) => 
            Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");

        public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message) => 
            Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");

        public void OnUnityAdsShowStart(string _adUnitId){}

        public void OnUnityAdsShowClick(string _adUnitId){}

        public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState){}
    }
}