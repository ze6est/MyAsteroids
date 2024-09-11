using System;
using Cysharp.Threading.Tasks;
using Firebase.RemoteConfig;
using MyAsteroids.CodeBase.Data;
using UnityEngine;

namespace MyAsteroids.CodeBase.Services.RemoteConfig
{
    public class FirebaseRemoteConfig : IRemoteConfig
    {
        private GameData _datas;

        public FirebaseRemoteConfig(GameData datas)
        {
            _datas = datas;
        }

        public async UniTask GetRemoteConfigsAsync()
        {
            Firebase.RemoteConfig.FirebaseRemoteConfig remoteConfig = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance;

            await remoteConfig.FetchAsync(TimeSpan.Zero).AsUniTask();

            if (remoteConfig.Info.LastFetchStatus != LastFetchStatus.Success)
                return;
            
            await remoteConfig.ActivateAsync().AsUniTask();

            string json = remoteConfig.GetValue(_datas.GetType().Name).StringValue;

            if (!string.IsNullOrEmpty(json))
            {
                GameData data = JsonUtility.FromJson<GameData>(json);
                
                _datas.ShipData = data.ShipData;
                _datas.AmmunitionsData = data.AmmunitionsData;
                _datas.BulletPoolData = data.BulletPoolData;
                _datas.LaserPoolData = data.LaserPoolData;
                _datas.SpawnerData = data.SpawnerData;
                _datas.AsteroidData = data.AsteroidData;
                _datas.AsteroidSmallData = data.AsteroidSmallData;
                _datas.UfoData = data.UfoData;
                _datas.AsteroidPoolData = data.AsteroidPoolData;
                _datas.AsteroidSmallPoolData = data.AsteroidSmallPoolData;
                _datas.UfoPoolData = data.UfoPoolData;
            }
        }
    }
}