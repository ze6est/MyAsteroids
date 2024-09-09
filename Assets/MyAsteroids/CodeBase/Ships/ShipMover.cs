using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Inputs;
using MyAsteroids.CodeBase.Logic;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ships
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipMover : MonoBehaviour, IRestarter
    {
        private float _acceleration;
        private float _deceleration;
        private float _maxSpeed;

        private Rigidbody2D _rigidbody;
        private ShipInputs _shipInputs;

        private float _moveInput;
        
        public float Velocity { get; private set; }

        [Inject]
        public void Construct(GameData data, ShipInputs shipInputs)
        {
            _acceleration = data.ShipData.Acceleration;
            _deceleration = data.ShipData.Deceleration;
            _maxSpeed = data.ShipData.MaxSpeed;

            _shipInputs = shipInputs;
        }

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody2D>();

        private void OnEnable() =>
            _shipInputs.Moved += OnMoved;

        private void Update() =>
            Move();

        private void OnDisable() =>
            _shipInputs.Moved -= OnMoved;
        
        public void Restart()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _rigidbody.velocity = Vector2.zero;
        }

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
            
            Velocity = transform.InverseTransformDirection(_rigidbody.velocity).y;
        }
    }
}