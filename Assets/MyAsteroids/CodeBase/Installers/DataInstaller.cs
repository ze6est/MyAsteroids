using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Logic;
using MyAsteroids.CodeBase.Services;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class DataInstaller : MonoInstaller
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private LoadingCurtain _curtain;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_gameData);

            
            LoadingCurtain curtain = Container.InstantiatePrefabForComponent<LoadingCurtain>(_curtain);

            Container.BindInstance(curtain);
            Container.Bind<InitialEntryPoint>().AsSingle().NonLazy();
            Container.Bind<FirebaseRemoteConfig>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}