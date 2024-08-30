using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Spawners;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Factories.Ammunitions.Bullets
{
    public class BulletSpawnerFactory
    {
        private Bullet _prefab;
        private Transform _container;
        private BulletPoolData _bulletPoolData;
        private IInstantiator _instantiator;

        public BulletSpawnerFactory(Bullet prefab, Transform container, BulletPoolData bulletPoolData,
            IInstantiator instantiator)
        {
            _prefab = prefab;
            _container = container;
            _bulletPoolData = bulletPoolData;
            _instantiator = instantiator;
        }

        public BulletSpawner Create() => 
            new(_prefab, _container, _bulletPoolData, _instantiator);
    }
}