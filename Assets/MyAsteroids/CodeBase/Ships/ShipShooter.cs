using System.Collections.Generic;
using MyAsteroids.CodeBase.Gun;
using MyAsteroids.CodeBase.Logic;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ships
{
    public class ShipShooter : MonoBehaviour, IRestarter
    {
        [SerializeField] private ShipModel _model;
        
        private List<BulletGun> _bulletsGun;
        private LaserGun _laserGun;

        [Inject]
        public void Construct()
        {
            _bulletsGun = _model.GetBulletGuns();
            _laserGun = _model.GetLaserGun();
        }

        public void BulletShoot()
        {
            foreach (BulletGun bulletGun in _bulletsGun)
                bulletGun.Shoot();
        }
        
        public void LaserShoot() => 
            _laserGun.Shoot();

        public void Restart()
        {
            foreach (BulletGun bulletGun in _bulletsGun)
            {
                bulletGun.Restart();
            }
            
            _laserGun.Restart();
        }
    }
}