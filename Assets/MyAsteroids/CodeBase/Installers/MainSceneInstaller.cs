using MyAsteroids.CodeBase.Logic;
using MyAsteroids.CodeBase.UI;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private ShipHUD _shipHUD;
        [SerializeField] private RestartWindow _restartWindow;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_shipHUD);
            Container.BindInstance(_restartWindow);
            
            Container.Bind<EntryPoint>().AsSingle().NonLazy();
            Container.Bind<Restarter>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle().NonLazy();
        }
    }
}