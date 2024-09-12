using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Logic;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ships
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipMover : MonoBehaviour, IRestarter
    {
        private ShipData _data;
        
        private float _acceleration;
        private float _deceleration;
        private float _maxSpeed;

        private Rigidbody2D _rigidbody;
        
        public float Velocity { get; private set; }

        [Inject]
        public void Construct(ShipData data) => 
            _data = data;

        private void Awake()
        {
            _acceleration = _data.Acceleration;
            _deceleration = _data.Deceleration;
            _maxSpeed = _data.MaxSpeed;
            
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Restart()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _rigidbody.velocity = Vector2.zero;
        }

        public void Move(float moveInput, float deltaTime)
        {
            _rigidbody.AddRelativeForce(moveInput * _acceleration * deltaTime * Vector2.up, ForceMode2D.Force);

            _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, _maxSpeed);

            if (moveInput <= 0)
            {
                float velocityX = Mathf.Lerp(_rigidbody.velocity.x, 0, _deceleration * deltaTime);
                float velocityY = Mathf.Lerp(_rigidbody.velocity.y, 0, _deceleration * deltaTime);

                _rigidbody.velocity = new Vector2(velocityX, velocityY);
            }
            
            Velocity = transform.InverseTransformDirection(_rigidbody.velocity).y;
        }
    }
}