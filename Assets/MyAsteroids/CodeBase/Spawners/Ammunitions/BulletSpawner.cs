using System.Collections.Generic;
using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data.Ammunitions;
using MyAsteroids.CodeBase.Pool.Ammunitions;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Spawners.Ammunitions
{
    public class BulletSpawner : IRestarter
    {
        private BulletPool _pool;

        private List<Bullet> _activeBullet;
        
        public BulletSpawner(Bullet prefab, Transform container, BulletPoolData bulletPoolData, IInstantiator instantiator)
        {
            _pool = new BulletPool(prefab, container, bulletPoolData, instantiator);
            _activeBullet = new();
        }
        
        public void Spawn(Vector2 position, Quaternion rotation)
        {
            Bullet bullet = _pool.GetFreeObject();

            if (bullet != null)
            {
                _activeBullet.Add(bullet);
                
                Transform bulletTransform = bullet.transform;
            
                bulletTransform.position = position;
                bulletTransform.rotation = rotation;
            
                bullet.Destroyed += OnDestroyed;
            }
        }
        
        public void Restart()
        {
            foreach (Bullet bullet in _activeBullet)
            {
                bullet.Destroyed -= OnDestroyed;
                _pool.Release(bullet);
            }
            
            _activeBullet.Clear();
        }

        private void OnDestroyed(Bullet bullet)
        {
            _activeBullet.Remove(bullet);
            bullet.Destroyed -= OnDestroyed;
            _pool.Release(bullet);
        }
    }
}