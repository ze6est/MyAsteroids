using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data.Ammunitions;
using MyAsteroids.CodeBase.Pool.Ammunitions;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Spawners.Ammunitions
{
    public class BulletSpawner
    {
        private BulletPool _pool;
        
        public BulletSpawner(Bullet prefab, Transform container, BulletPoolData bulletPoolData, IInstantiator instantiator)
        {
            _pool = new BulletPool(prefab, container, bulletPoolData, instantiator);
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