using System;
using UnityEngine;

namespace MyAsteroids.CodeBase.Data
{
    [Serializable]
    public class AdsData : IData
    {
        [Header("Ads settings")]
        public string AndroidGameId = "5694287";
        public string IOSGameId = "5694286";
        public bool TestMode = true;
        
        [Header("Interstitial settings")]
        public string AndroidAdUnitId = "Interstitial_Android";
        public string IOsAdUnitId = "Interstitial_iOS";
    }
}