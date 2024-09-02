using System.Collections.Generic;
using MyAsteroids.CodeBase.Gun;
using MyAsteroids.CodeBase.Inputs;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ships
{
    public class ShipShooter : MonoBehaviour, IRestarter
    {
        [SerializeField] private ShipModel _model;
        
        private ShipInputs _shipInputs;
        private List<BulletGun> _bulletsGun;
        private LaserGun _laserGun;

        [Inject]
        public void Construct(ShipInputs shipInputs)
        {
            _bulletsGun = _model.GetBulletGuns();
            _laserGun = _model.GetLaserGun();
            _shipInputs = shipInputs;
        }

        private void OnEnable()
        {
            _shipInputs.BulletShooted += OnBulletShooted;
            _shipInputs.LaserShooted += OnLaserShooted;
        }

        private void OnDisable()
        {
            _shipInputs.BulletShooted -= OnBulletShooted;
            _shipInputs.LaserShooted -= OnLaserShooted;
        }

        public void OnBulletShooted()
        {
            foreach (BulletGun bulletGun in _bulletsGun)
                bulletGun.Shoot();
        }
        
        public void OnLaserShooted() => 
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