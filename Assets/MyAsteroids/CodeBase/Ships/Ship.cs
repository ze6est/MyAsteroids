using MyAsteroids.CodeBase.Gun;
using MyAsteroids.CodeBase.Logic;
using UnityEngine;

namespace MyAsteroids.CodeBase.Ships
{
    [RequireComponent(typeof(ShipMover))]
    public class Ship : MonoBehaviour, IRestarter
    {
        [field:SerializeField] public ShipMover Mover { get; private set; }
        [field:SerializeField] public ShipRotator Rotator { get; private set; }
        [field:SerializeField] public ShipShooter Shooter { get; private set; }
        [field:SerializeField] public ShipTriggerObserver TriggerObserver { get; private set; }
        [field:SerializeField] public LaserGun LaserGun { get; private set; }
        
        public void Restart()
        {
            Mover.Restart();
            Shooter.Restart();
        }
    }
}