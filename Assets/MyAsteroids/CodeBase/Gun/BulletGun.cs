using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Factories;
using MyAsteroids.CodeBase.Spawners;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Gun
{
    public class BulletGun : MonoBehaviour
    {
        [SerializeField] private Bullet _prefab;
        
        private BulletSpawner _bulletSpawner;
        private Transform _transform;

        [Inject]
        public void Construct(BulletPoolData bulletPoolData, IInstantiator instantiator)
        {
            BulletSpawnerFactory bulletSpawnerFactory = new BulletSpawnerFactory(_prefab, transform, bulletPoolData, instantiator);
            _bulletSpawner = bulletSpawnerFactory.Create();
            _transform = transform;
        }
        
        public void Shoot() => 
            _bulletSpawner.Spawn(_transform.position, _transform.rotation);
    }
}