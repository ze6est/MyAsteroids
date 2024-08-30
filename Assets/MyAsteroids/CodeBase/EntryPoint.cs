using MyAsteroids.CodeBase.Factories;
using MyAsteroids.CodeBase.Gun;
using MyAsteroids.CodeBase.Ships;
using MyAsteroids.CodeBase.UI;
using Zenject;

namespace MyAsteroids.CodeBase
{
    public class EntryPoint : IInitializable
    {
        private ShipFactory _shipFactory;
        private ShipHUD _shipHUD;

        public EntryPoint(ShipFactory shipFactory, ShipHUD shipHUD)
        {
            _shipFactory = shipFactory;
            _shipHUD = shipHUD;
        }

        public void Initialize()
        {
            Ship ship = _shipFactory.CreateShip();

            //хреновый код
            if (ship.TryGetComponent(out ShipMover shipMover))
            {
                LaserGun laserGun = ship.GetComponentInChildren<LaserGun>();
                
                _shipHUD.Construct(shipMover, laserGun);
            }
        }
    }
}