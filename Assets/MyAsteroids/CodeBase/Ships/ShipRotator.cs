using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Inputs;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ships
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipRotator : MonoBehaviour
    {
        private GameData _data;
        
        private float _speed;
        
        private Rigidbody2D _rigidbody;
        private Camera _camera;

        [Inject]
        public void Construct(GameData data) => 
            _data = data;

        private void Awake()
        {
            _speed = _data.ShipData.RotateSpeed;
            
            _rigidbody = GetComponent<Rigidbody2D>();
            
            _camera = Camera.main;
        }

        public void Rotate(Vector2 lookDirection, float deltaTime)
        {
            Vector2 direction = _camera.ScreenToWorldPoint(lookDirection) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            _rigidbody.rotation = Mathf.LerpAngle(_rigidbody.rotation, angle, _speed * deltaTime);
        }
    }
}