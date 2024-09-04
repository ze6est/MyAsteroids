using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Services;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class DataInstaller : MonoInstaller
    {
        [SerializeField] private GameData _gameData;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_gameData);
            
            Container.Bind<FirebaseRemoteConfig>().AsSingle().NonLazy();
        }
    }
}