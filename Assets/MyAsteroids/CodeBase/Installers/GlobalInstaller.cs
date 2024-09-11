using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Logic;
using MyAsteroids.CodeBase.Services.RemoteConfig;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private LoadingCurtain _curtain;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_gameData);
            
            LoadingCurtain curtain = Container.InstantiatePrefabForComponent<LoadingCurtain>(_curtain);

            Container.BindInstance(curtain);
            Container.BindInterfacesTo<EntryPoint>().AsSingle().NonLazy();
            Container.BindInterfacesTo<FirebaseRemoteConfig>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}