using MyAsteroids.CodeBase.Ships;
using Zenject;

namespace MyAsteroids.CodeBase.Factories
{
    public class ShipFactory
    {
        private readonly IInstantiator _instantiator;
        private Ship _shipPrefab;
        
        public ShipFactory(IInstantiator instantiator, Ship shipPrefab)
        {
            _instantiator = instantiator;
            _shipPrefab = shipPrefab;
        }
        
        public Ship CreateShip() => 
            _instantiator.InstantiatePrefabForComponent<Ship>(_shipPrefab);
    }
}