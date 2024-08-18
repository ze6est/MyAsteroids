using MyAsteroids.CodeBase.Factories;
using Zenject;

namespace MyAsteroids.CodeBase
{
    public class EntryPoint : IInitializable
    {
        private ShipFactory _shipFactory;

        public EntryPoint(ShipFactory shipFactory) => 
            _shipFactory = shipFactory;

        public void Initialize() => 
            _shipFactory.CreateShip();
    }
}