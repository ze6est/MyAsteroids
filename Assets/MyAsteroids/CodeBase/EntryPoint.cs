using MyAsteroids.CodeBase.Factories;
using MyAsteroids.CodeBase.Ships;
using MyAsteroids.CodeBase.Spawners;
using MyAsteroids.CodeBase.UI;

namespace MyAsteroids.CodeBase
{
    public class EntryPoint
    {
        private ShipFactory _shipFactory;
        private ShipHUD _shipHUD;
        
        public EntryPoint(ShipFactory shipFactory, ShipHUD shipHUD, EnemiesSpawner enemiesSpawner, Restarter restarter)
        {
            _shipFactory = shipFactory;
            _shipHUD = shipHUD;

            Ship ship = _shipFactory.CreateShip();
            
            _shipHUD.Construct(ship);
            restarter.SetShip(ship);
            
            enemiesSpawner.Start(ship);
        }
    }
}