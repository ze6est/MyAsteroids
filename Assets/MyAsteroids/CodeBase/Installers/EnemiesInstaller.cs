using MyAsteroids.CodeBase.Data.Enemies;
using MyAsteroids.CodeBase.Data.Enemies.Pools;
using MyAsteroids.CodeBase.Enemies;
using MyAsteroids.CodeBase.Pool.Enemies;
using MyAsteroids.CodeBase.Spawners;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class EnemiesInstaller : MonoInstaller
    {
        [SerializeField] private EnemiesSpawnerData _spawnerData;
        [Header("Prefabs")]
        [SerializeField] private Asteroid _asteroidPrefab;
        [SerializeField] private AsteroidSmall _asteroidSmallPrefab;
        [SerializeField] private Ufo _ufoPrefab;

        [Header("Enemies data")] 
        [SerializeField] private AsteroidData _asteroidData;
        [SerializeField] private AsteroidSmallData _asteroidSmallData;
        [SerializeField] private UfoData _ufoData;
        
        [Header("Pools")]
        [SerializeField] private AsteroidPoolData _asteroidPoolData;
        [SerializeField] private AsteroidSmallPoolData _asteroidSmallPoolData;
        [SerializeField] private UfoPoolData _ufoPoolData;
        
        [Header("Enemies container")]
        [SerializeField] private Transform _enemiesContainer;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_spawnerData);

            Container.BindInstance(_asteroidData);
            Container.BindInstance(_asteroidSmallData);
            Container.BindInstance(_ufoData);
            
            Container.BindInstance(_asteroidPoolData);
            Container.Bind<AsteroidPool>().AsSingle().WithArguments(_asteroidPrefab, _enemiesContainer);

            Container.BindInstance(_asteroidSmallPoolData);
            Container.Bind<AsteroidSmallPool>().AsSingle().WithArguments(_asteroidSmallPrefab, _enemiesContainer);

            Container.BindInstance(_ufoPoolData);
            Container.Bind<UfoPool>().AsSingle().WithArguments(_ufoPrefab, _enemiesContainer);
            
            Container.BindInterfacesAndSelfTo<EnemiesSpawner>().AsSingle().NonLazy();
        }
    }
}