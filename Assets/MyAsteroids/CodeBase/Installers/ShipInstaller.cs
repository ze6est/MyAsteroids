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
            Container.BindInstance(_shipConfig);
            Container.Bind<ShipInputs>().AsSingle();
            
            Container.Bind<Ship>().FromFactory<ShipFactory>().AsSingle();
        }
    }
}