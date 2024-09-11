using MyAsteroids.CodeBase.Configs;
using MyAsteroids.CodeBase.Ships;
using Zenject;

namespace MyAsteroids.CodeBase.Factories
{
    public class ShipFactory : IFactory<Ship>
    {
        private readonly ShipConfig _shipConfig;
        private readonly IInstantiator _instantiator;

        public ShipFactory(ShipConfig shipConfig, IInstantiator instantiator)
        {
            _shipConfig = shipConfig;
            _instantiator = instantiator;
        }

        public Ship Create() => 
            _instantiator.InstantiatePrefabForComponent<Ship>(_shipConfig.ShipPrefab);
    }
}