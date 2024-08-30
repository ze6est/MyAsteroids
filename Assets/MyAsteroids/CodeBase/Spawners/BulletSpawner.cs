using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Factories.Ammunitions.Bullets;
using MyAsteroids.CodeBase.Pool;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Spawners
{
    public class BulletSpawner
    {
        private BulletPool _pool;
        
        public BulletSpawner(Bullet prefab, Transform container, BulletPoolData bulletPoolData, IInstantiator instantiator)
        {
            BulletPoolFactory bulletPoolFactory = new BulletPoolFactory(prefab, container, bulletPoolData, instantiator);
            _pool = bulletPoolFactory.Create();
        }
        
        public void Spawn(Vector2 position, Quaternion rotation)
        {
            Bullet bullet = _pool.GetFreeObject();

            if (bullet != null)
            {
                Transform bulletTransform = bullet.transform;
            
                bulletTransform.position = position;
                bulletTransform.rotation = rotation;
            
                bullet.Destroyed += OnDestroyed;
            }
        }

        private void OnDestroyed(Bullet bullet)
        {
            bullet.Destroyed -= OnDestroyed;
            _pool.Release(bullet);
        }
    }
}