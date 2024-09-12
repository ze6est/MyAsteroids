using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Firebase.RemoteConfig;
using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Data.Ammunitions;
using MyAsteroids.CodeBase.Data.Enemies;
using MyAsteroids.CodeBase.Data.Enemies.Pools;
using UnityEngine;

namespace MyAsteroids.CodeBase.Services.RemoteConfig
{
    public class FirebaseRemoteConfig : IRemoteConfig, IDataProvider
    {
        private GameData _gameData;
        
        private Dictionary<Type, IData> _datas;

        public FirebaseRemoteConfig(GameData gameData) => 
            _gameData = gameData;

        public async UniTask GetRemoteConfigsAsync()
        {
            Firebase.RemoteConfig.FirebaseRemoteConfig remoteConfig = 
                Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance;

            await remoteConfig.FetchAsync(TimeSpan.Zero).AsUniTask();

            if (remoteConfig.Info.LastFetchStatus != LastFetchStatus.Success)
                return;

            await remoteConfig.ActivateAsync().AsUniTask();

            string json = remoteConfig.GetValue(_gameData.GetType().Name).StringValue;

            if (!string.IsNullOrEmpty(json))
            {
                GameData data = JsonUtility.FromJson<GameData>(json);
                
                _datas = new Dictionary<Type, IData>
                {
                    [typeof(ShipData)] = data.ShipData,
                    [typeof(AmmunitionsData)] = data.AmmunitionsData,
                    [typeof(BulletPoolData)] = data.BulletPoolData,
                    [typeof(LaserPoolData)] = data.LaserPoolData,
                    [typeof(EnemiesSpawnerData)] = data.SpawnerData,
                    [typeof(AsteroidData)] = data.AsteroidData,
                    [typeof(AsteroidSmallData)] = data.AsteroidSmallData,
                    [typeof(UfoData)] = data.UfoData,
                    [typeof(AsteroidPoolData)] = data.AsteroidPoolData,
                    [typeof(AsteroidSmallPoolData)] = data.AsteroidSmallPoolData,
                    [typeof(UfoPoolData)] = data.UfoPoolData,
                    [typeof(AdsData)] = data.AdsData,
                };
            }
        }

        public T Load<T>() where T : IData => 
            (T)_datas[typeof(T)];
    }
}