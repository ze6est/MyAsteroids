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

                _gameData.ShipData = data.ShipData;
                _gameData.AmmunitionsData = data.AmmunitionsData;
                _gameData.BulletPoolData = data.BulletPoolData;
                _gameData.LaserPoolData = data.LaserPoolData;
                _gameData.SpawnerData = data.SpawnerData;
                _gameData.AsteroidData = data.AsteroidData;
                _gameData.AsteroidSmallData = data.AsteroidSmallData;
                _gameData.UfoData = data.UfoData;
                _gameData.AsteroidPoolData = data.AsteroidPoolData;
                _gameData.AsteroidSmallPoolData = data.AsteroidSmallPoolData;
                _gameData.UfoPoolData = data.UfoPoolData;
            }
            
            _datas = new Dictionary<Type, IData>
            {
                [typeof(ShipData)] = _gameData.ShipData,
                [typeof(AmmunitionsData)] = _gameData.AmmunitionsData,
                [typeof(BulletPoolData)] = _gameData.BulletPoolData,
                [typeof(LaserPoolData)] = _gameData.LaserPoolData,
                [typeof(EnemiesSpawnerData)] = _gameData.SpawnerData,
                [typeof(AsteroidData)] = _gameData.AsteroidData,
                [typeof(AsteroidSmallData)] = _gameData.AsteroidSmallData,
                [typeof(UfoData)] = _gameData.UfoData,
                [typeof(AsteroidPoolData)] = _gameData.AsteroidPoolData,
                [typeof(AsteroidSmallPoolData)] = _gameData.AsteroidSmallPoolData,
                [typeof(UfoPoolData)] = _gameData.UfoPoolData,
            };
        }

        public T Load<T>() where T : IData => 
            (T)_datas[typeof(T)];
    }
}