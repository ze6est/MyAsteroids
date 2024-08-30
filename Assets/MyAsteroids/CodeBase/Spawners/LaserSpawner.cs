using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Factories.Ammunitions.Lasers;
using MyAsteroids.CodeBase.Pool;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Spawners
{
    public class LaserSpawner
    {
        private LaserPool _pool;
        
        public LaserSpawner(Laser prefab, Transform container, LaserPoolData laserPoolData, IInstantiator instantiator)
        {
            LaserPoolFactory laserPoolFactory = new LaserPoolFactory(prefab, container, laserPoolData, instantiator);
            _pool = laserPoolFactory.Create();
        }
        
        public void Spawn(Vector2 position, Quaternion rotation)
        {
            Laser laser = _pool.GetFreeObject();

            if (laser != null)
            {
                Transform laserTransform = laser.transform;
            
                laserTransform.position = position;
                laserTransform.rotation = rotation;
            
                laser.Destroyed += OnDestroyed;
            }
        }

        private void OnDestroyed(Laser laser)
        {
            laser.Destroyed -= OnDestroyed;
            _pool.Release(laser);
        }
    }
}