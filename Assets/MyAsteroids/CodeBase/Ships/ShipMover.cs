using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Inputs;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ships
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipMover : MonoBehaviour
    {
        private float _acceleration;
        private float _deceleration;
        private float _maxSpeed;
        
        private Rigidbody2D _rigidbody;
        private ShipInputs _shipInputs;

        private float _moveInput;
        
        [Inject]
        public void Construct(ShipData shipData, ShipInputs shipInputs)
        {
            _acceleration = shipData.Acceleration;
            _deceleration = shipData.Deceleration;
            _maxSpeed = shipData.MaxSpeed;
           
            _shipInputs.Moved += OnMoved;
        }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update() => 
            Move();

        private void OnDestroy() => 
            _shipInputs.Moved -= OnMoved;

        private void OnMoved(float speed) => 
            _moveInput = speed;

        private void Move()
        {
            _rigidbody.AddRelativeForce(_moveInput * _acceleration * Time.deltaTime * Vector2.up, ForceMode2D.Force);
            
            _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
            
            if (_moveInput <= 0)
            {
                float velocityX = Mathf.Lerp(_rigidbody.velocity.x, 0, _deceleration * Time.deltaTime);
                float velocityY = Mathf.Lerp(_rigidbody.velocity.y, 0, _deceleration * Time.deltaTime);

                _rigidbody.velocity = new Vector2(velocityX, velocityY);
            }
        }
    }
}
