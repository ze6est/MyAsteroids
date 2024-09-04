using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Inputs;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ships
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipRotator : MonoBehaviour
    {
        private float _speed;
        
        private ShipInputs _shipInputs;
        private Rigidbody2D _rigidbody;
        private Camera _camera;

        private Coroutine _rotateJob;

        private Vector2 _lookTo;

        [Inject]
        public void Construct(GameData data, ShipInputs shipInputs)
        {
            _speed = data.ShipData.RotateSpeed;
            _shipInputs = shipInputs;
        }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _camera = Camera.main;
        }

        private void OnEnable() => 
            _shipInputs.Rotated += OnRotated;

        private void Update() => 
            Rotate();

        private void OnDisable() => 
            _shipInputs.Rotated -= OnRotated;

        private void OnRotated(Vector2 lookTo) => 
            _lookTo = lookTo;

        private void Rotate()
        {
            Vector2 direction = _camera.ScreenToWorldPoint(_lookTo) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            _rigidbody.rotation = Mathf.LerpAngle(_rigidbody.rotation, angle, _speed * Time.deltaTime);
        }
    }
}