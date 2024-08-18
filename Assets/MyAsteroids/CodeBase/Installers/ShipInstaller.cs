using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Factories;
using MyAsteroids.CodeBase.Inputs;
using MyAsteroids.CodeBase.Ships;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class ShipInstaller : MonoInstaller
    {
        [SerializeField] private Ship _shipPrefab;
        [SerializeField] private ShipData _shipData;

        public override void InstallBindings()
        {
            Container.Bind<ShipInputs>().AsSingle();
            Container.BindInstance(_shipData);

            Container.Bind<ShipFactory>().AsSingle().WithArguments(_shipPrefab);
            
            Container.Bind<Ship>().AsSingle();
            Container.Bind<ShipMover>().AsSingle();
            Container.Bind<ShipRotator>().AsSingle();
        }
    }
}
