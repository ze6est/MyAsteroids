using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Data.Ammunitions;
using MyAsteroids.CodeBase.Data.Enemies;
using MyAsteroids.CodeBase.Data.Enemies.Pools;
using MyAsteroids.CodeBase.Factories;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class DataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ShipData>().FromFactory<DataFactory<ShipData>>().AsSingle();
            Container.Bind<AmmunitionsData>().FromFactory<DataFactory<AmmunitionsData>>().AsSingle();
            Container.Bind<BulletPoolData>().FromFactory<DataFactory<BulletPoolData>>().AsSingle();
            Container.Bind<LaserPoolData>().FromFactory<DataFactory<LaserPoolData>>().AsSingle();
            Container.Bind<AsteroidData>().FromFactory<DataFactory<AsteroidData>>().AsSingle();
            Container.Bind<AsteroidSmallData>().FromFactory<DataFactory<AsteroidSmallData>>().AsSingle();
            Container.Bind<UfoData>().FromFactory<DataFactory<UfoData>>().AsSingle();
            Container.Bind<AsteroidPoolData>().FromFactory<DataFactory<AsteroidPoolData>>().AsSingle();
            Container.Bind<AsteroidSmallPoolData>().FromFactory<DataFactory<AsteroidSmallPoolData>>().AsSingle();
            Container.Bind<UfoPoolData>().FromFactory<DataFactory<UfoPoolData>>().AsSingle();
            Container.Bind<EnemiesSpawnerData>().FromFactory<DataFactory<EnemiesSpawnerData>>().AsSingle();
        }
    }
}