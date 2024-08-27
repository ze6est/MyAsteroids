using System.Collections.Generic;
using MyAsteroids.CodeBase.Gun;
using MyAsteroids.CodeBase.Inputs;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ships
{
    public class ShipShooter : MonoBehaviour
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

        private void OnEnable() => 
            _shipInputs.BulletShooted += OnBulletShooted;

        private void OnDisable() => 
            _shipInputs.BulletShooted -= OnBulletShooted;

        public void OnBulletShooted()
        {
            foreach (BulletGun bulletGun in _bulletsGun)
                bulletGun.Shoot();
        }
    }
}