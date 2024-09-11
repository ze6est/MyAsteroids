using System;
using MyAsteroids.CodeBase.Inputs;
using MyAsteroids.CodeBase.Logic;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ships
{
    public class ShipController : IInitializable, ITickable, IFixedTickable, IDisposable, IRestarter
    {
        private readonly ShipInputHandler _inputHandler;
        private readonly ShipMover _mover;
        private readonly ShipRotator _rotator;
        private readonly ShipShooter _shooter;
        private readonly ShipTriggerObserver _triggerObserver;

        private float _moveInput;
        private Vector2 _lookDirection;

        public ShipController(ShipInputHandler inputHandler, Ship ship)
        {
            _inputHandler = inputHandler;
            _mover = ship.Mover;
            _rotator = ship.Rotator;
            _shooter = ship.Shooter;
            _triggerObserver = ship.TriggerObserver;
        }
        
        public void Initialize()
        {
            _inputHandler.MoveEnable();
            _inputHandler.LookToEnable();
            _inputHandler.BulletShootEnable();
            _inputHandler.LaserShootEnable();
            
            _inputHandler.BulletShooted += OnBulletShooted;
            _inputHandler.LaserShooted += OnLaserShooted;
            _triggerObserver.Died += OnDied;
        }

        public void Tick()
        {
            _moveInput = _inputHandler.MoveInput;
            _lookDirection = _inputHandler.LookDirection;
        }

        public void FixedTick()
        {
            _mover.Move(_moveInput, Time.fixedDeltaTime);
            _rotator.Rotate(_lookDirection, Time.fixedDeltaTime);
        }
        
        public void Dispose()
        {
            _inputHandler.BulletShooted -= OnBulletShooted;
            _inputHandler.LaserShooted -= OnLaserShooted;
            
            _inputHandler.MoveDisable();
            _inputHandler.LookToDisable();
            _inputHandler.BulletShootDisable();
            _inputHandler.LaserShootDisable();
        }
        
        public void Restart()
        {
            _inputHandler.BulletShootEnable();
            _inputHandler.LaserShootEnable();
        }
        
        private void OnDied()
        {
            _inputHandler.BulletShootDisable();
            _inputHandler.LaserShootDisable();
        }
        
        private void OnBulletShooted() => 
            _shooter.BulletShoot();

        private void OnLaserShooted() => 
            _shooter.LaserShoot();
    }
}