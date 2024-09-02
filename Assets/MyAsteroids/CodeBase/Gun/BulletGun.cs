using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data.Ammunitions;
using MyAsteroids.CodeBase.Spawners.Ammunitions;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Gun
{
    public class BulletGun : MonoBehaviour, IRestarter
    {
        [SerializeField] private Bullet _prefab;
        
        private BulletSpawner _bulletSpawner;
        private Transform _transform;

        [Inject]
        public void Construct(BulletPoolData bulletPoolData, IInstantiator instantiator)
        {
            _transform = transform;
            _bulletSpawner = new BulletSpawner(_prefab, _transform, bulletPoolData, instantiator);
        }
        
        public void Shoot() => 
            _bulletSpawner.Spawn(_transform.position, _transform.rotation);

        public void Restart()
        {
            _bulletSpawner.Restart();
        }
    }
}