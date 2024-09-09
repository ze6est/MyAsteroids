using MyAsteroids.CodeBase.Gun;
using MyAsteroids.CodeBase.Inputs;
using MyAsteroids.CodeBase.Logic;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ships
{
    [RequireComponent(typeof(ShipMover))]
    public class Ship : MonoBehaviour, IRestarter
    {
        [SerializeField] private ShipMover _shipMover;
        [SerializeField] private ShipShooter _shipShooter;
        [SerializeField] private ShipTriggerObserver _shipTriggerObserver;
        [SerializeField] private LaserGun _laserGun;
        
        private ShipInputs _shipInputs;

        public ShipMover ShipMover => 
            _shipMover;
        public ShipTriggerObserver ShipTriggerObserver => 
            _shipTriggerObserver;
        public LaserGun LaserGun => 
            _laserGun;
        
        [Inject]
        public void Construct(ShipInputs shipInputs) => 
            _shipInputs = shipInputs;

        private void OnEnable() => 
            _shipInputs.Enable();

        private void OnDisable() => 
            _shipInputs.Disable();
        
        public void Restart()
        {
            _shipMover.Restart();
            _shipShooter.Restart();
        }
    }
}