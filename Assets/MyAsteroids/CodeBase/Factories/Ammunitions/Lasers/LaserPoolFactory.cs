using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Pool;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Factories.Ammunitions.Lasers
{
    public class LaserPoolFactory
    {
        private Laser _prefab;
        private Transform _container;
        private LaserPoolData _laserPoolData;
        private IInstantiator _instantiator;

        public LaserPoolFactory(Laser prefab, Transform container, LaserPoolData laserPoolData, IInstantiator instantiator)
        {
            _prefab = prefab;
            _container = container;
            _laserPoolData = laserPoolData;
            _instantiator = instantiator;
        }

        public LaserPool Create() => 
            new(_prefab, _container, _laserPoolData, _instantiator);
    }
}