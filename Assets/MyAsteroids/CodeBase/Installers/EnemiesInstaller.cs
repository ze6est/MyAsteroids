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
        [Header("Prefabs")]
        [SerializeField] private Asteroid _asteroidPrefab;
        [SerializeField] private AsteroidSmall _asteroidSmallPrefab;
        [SerializeField] private Ufo _ufoPrefab;
        
        [Header("Enemies container")]
        [SerializeField] private Transform _enemiesContainer;
        
        public override void InstallBindings()
        {
            Container.Bind<AsteroidPool>().AsSingle().WithArguments(_asteroidPrefab, _enemiesContainer);
            
            Container.Bind<AsteroidSmallPool>().AsSingle().WithArguments(_asteroidSmallPrefab, _enemiesContainer);
            
            Container.Bind<UfoPool>().AsSingle().WithArguments(_ufoPrefab, _enemiesContainer);
            
            Container.BindInterfacesAndSelfTo<EnemiesSpawner>().AsSingle().NonLazy();
        }
    }
}