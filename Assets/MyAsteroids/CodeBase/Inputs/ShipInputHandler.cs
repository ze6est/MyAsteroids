using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MyAsteroids.CodeBase.Inputs
{
    public class ShipInputHandler
    {
        private readonly InputAction _moveAction;
        private readonly InputAction _lookAction;
        private readonly InputAction _bulletShootAction;
        private readonly InputAction _laserShootAction;

        public float MoveInput { get; private set; }
        public Vector2 LookDirection { get; private set; }
        
        public event UnityAction BulletShooted;
        public event UnityAction LaserShooted;

        public ShipInputHandler(InputActions input)
        {
            _moveAction = input.ShipInput.Moved;
            _lookAction = input.ShipInput.LookTo;
            _bulletShootAction = input.ShipInput.BulletShooted;
            _laserShootAction = input.ShipInput.LaserShooted;
        }

        public void MoveEnable()
        {
            _moveAction.Enable();
            _moveAction.performed += OnMoved;
            _moveAction.canceled += OnMoved;
        }

        public void LookToEnable()
        {
            _lookAction.Enable();
            _lookAction.performed += OnLookTo;
            _lookAction.canceled += OnLookTo;
        }

        public void BulletShootEnable()
        {
            _bulletShootAction.Enable();
            _bulletShootAction.performed += OnBulletShooted;
        }

        public void LaserShootEnable()
        {
            _laserShootAction.Enable();
            _laserShootAction.performed += OnLaserShooted;
        }
        
        public void MoveDisable()
        {
            _moveAction.performed -= OnMoved;
            _moveAction.canceled -= OnMoved;
            _moveAction.Disable();
        }
        
        public void LookToDisable()
        {
            _lookAction.performed -= OnLookTo;
            _lookAction.canceled -= OnLookTo;
            _lookAction.Disable();
        }
        
        public void BulletShootDisable()
        {
            _bulletShootAction.performed -= OnBulletShooted;
            _bulletShootAction.Disable();
        }
        
        public void LaserShootDisable()
        {
            _laserShootAction.performed -= OnLaserShooted;
            _laserShootAction.Enable();
        }
        
        private void OnMoved(InputAction.CallbackContext context) => 
            MoveInput = context.ReadValue<float>();

        private void OnLookTo(InputAction.CallbackContext context) => 
            LookDirection = context.ReadValue<Vector2>();

        private void OnBulletShooted(InputAction.CallbackContext context) => 
            BulletShooted?.Invoke();

        private void OnLaserShooted(InputAction.CallbackContext context) =>
            LaserShooted?.Invoke();
    }
}