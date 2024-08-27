using System.Collections.Generic;
using MyAsteroids.CodeBase.Gun;
using UnityEngine;

namespace MyAsteroids.CodeBase.Ships
{
    public class ShipModel : MonoBehaviour
    {
        [SerializeField] private List<BulletGun> _bulletsGun;
        [SerializeField] private LaserGun _laserGun;

        public List<BulletGun> GetBulletGuns() => 
            _bulletsGun;

        public LaserGun GetLaserGun() => 
            _laserGun;
    }
}