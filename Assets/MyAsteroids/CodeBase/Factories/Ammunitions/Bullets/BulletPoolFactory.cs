using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Pool;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Factories.Ammunitions.Bullets
{
    public class BulletPoolFactory
    {
        private CodeBase.Ammunitions.Bullet _prefab;
        private Transform _container;
        private BulletPoolData _bulletPoolData;
        private IInstantiator _instantiator;

        public BulletPoolFactory(CodeBase.Ammunitions.Bullet prefab, Transform container, BulletPoolData bulletPoolData, IInstantiator instantiator)
        {
            _prefab = prefab;
            _container = container;
            _bulletPoolData = bulletPoolData;
            _instantiator = instantiator;
        }

        public BulletPool Create() => 
            new(_prefab, _container, _bulletPoolData, _instantiator);
    }
}