using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Logic;
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
        public void Construct(GameData data, IInstantiator instantiator)
        {
            _transform = transform;
            _bulletSpawner = new BulletSpawner(_prefab, _transform, data.BulletPoolData, instantiator);
        }
        
        public void Shoot() => 
            _bulletSpawner.Spawn(_transform.position, _transform.rotation);

        public void Restart()
        {
            _bulletSpawner.Restart();
        }
    }
}