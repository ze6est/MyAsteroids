using MyAsteroids.CodeBase.Ships;
using Zenject;

namespace MyAsteroids.CodeBase.Factories
{
    public class ShipFactory
    {
        private readonly DiContainer _diContainer;
        private Ship _shipPrefab;
        
        public ShipFactory(DiContainer diContainer, Ship shipPrefab)
        {
            _diContainer = diContainer;
            _shipPrefab = shipPrefab;
        }
        
        public Ship CreateShip() => 
            _diContainer.InstantiatePrefabForComponent<Ship>(_shipPrefab);
    }
}