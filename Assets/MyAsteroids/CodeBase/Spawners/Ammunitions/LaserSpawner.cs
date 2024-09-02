using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data.Ammunitions;
using MyAsteroids.CodeBase.Pool.Ammunitions;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Spawners.Ammunitions
{
    public class LaserSpawner
    {
        private LaserPool _pool;
        
        public LaserSpawner(Laser prefab, Transform container, LaserPoolData laserPoolData, IInstantiator instantiator)
        {
            _pool = new LaserPool(prefab, container, laserPoolData, instantiator);
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