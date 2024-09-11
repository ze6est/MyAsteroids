using MyAsteroids.CodeBase.Configs;
using MyAsteroids.CodeBase.Factories;
using MyAsteroids.CodeBase.Inputs;
using MyAsteroids.CodeBase.Ships;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class ShipInstaller : MonoInstaller
    {
        [SerializeField] private ShipConfig _shipConfig;

        public override void InstallBindings()
        {
            Container.Bind<InputActions>().AsSingle();
            Container.Bind<ShipInputHandler>().AsSingle();
            Container.BindInterfacesTo<ShipController>().AsSingle().NonLazy();
            
            Container.BindInstance(_shipConfig);
            
            Container.Bind<Ship>().FromFactory<ShipFactory>().AsSingle();
        }
    }
}