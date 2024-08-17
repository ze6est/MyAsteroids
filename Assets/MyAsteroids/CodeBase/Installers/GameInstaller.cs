using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Factories;
using MyAsteroids.CodeBase.Inputs;
using MyAsteroids.CodeBase.Ships;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private ShipData _shipData;
        
        private ShipInputs _shipInputs;

        public override void InstallBindings()
        {
            Container.Bind<ShipInputs>().AsSingle();
            Container.Bind<Ship>().FromFactory<ShipFactory>().AsSingle().WithArguments(_ship);
            Container.BindInstance(_shipData);
        }
    }
}