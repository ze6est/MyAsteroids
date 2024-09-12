using System;
using MyAsteroids.CodeBase.Data.Ammunitions;
using MyAsteroids.CodeBase.Data.Enemies;
using MyAsteroids.CodeBase.Data.Enemies.Pools;

namespace MyAsteroids.CodeBase.Data
{
    [Serializable]
    public class GameData
    {
        public ShipData ShipData;
        
        public AmmunitionsData AmmunitionsData;
        
        public BulletPoolData BulletPoolData;
        public LaserPoolData LaserPoolData;
        
        public EnemiesSpawnerData SpawnerData;
        
        public AsteroidData AsteroidData;
        public AsteroidSmallData AsteroidSmallData;
        public UfoData UfoData;
        
        public AsteroidPoolData AsteroidPoolData;
        public AsteroidSmallPoolData AsteroidSmallPoolData;
        public UfoPoolData UfoPoolData;

        public AdsData AdsData;
    }
}