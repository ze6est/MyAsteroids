using System.Collections.Generic;
using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data.Ammunitions;
using MyAsteroids.CodeBase.Pool.Ammunitions;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Spawners.Ammunitions
{
    public class LaserSpawner : IRestarter
    {
        private LaserPool _pool;
        
        private List<Laser> _activeLasers;
        
        public LaserSpawner(Laser prefab, Transform container, LaserPoolData laserPoolData, IInstantiator instantiator)
        {
            _pool = new LaserPool(prefab, container, laserPoolData, instantiator);
            _activeLasers = new();
        }
        
        public void Spawn(Vector2 position, Quaternion rotation)
        {
            Laser laser = _pool.GetFreeObject();

            if (laser != null)
            {
                _activeLasers.Add(laser);
                
                Transform laserTransform = laser.transform;
            
                laserTransform.position = position;
                laserTransform.rotation = rotation;
            
                laser.Destroyed += OnDestroyed;
            }
        }

        private void OnDestroyed(Laser laser)
        {
            _activeLasers.Remove(laser);
            laser.Destroyed -= OnDestroyed;
            _pool.Release(laser);
        }

        public void Restart()
        {
            foreach (Laser laser in _activeLasers)
            {
                laser.Destroyed -= OnDestroyed;
                _pool.Release(laser);
            }
            
            _activeLasers.Clear();
        }
    }
}