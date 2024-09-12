using System.Collections;
using MyAsteroids.CodeBase.Data.Enemies;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace MyAsteroids.CodeBase.Enemies
{
    public class Asteroid : Enemie
    {
        private float _maxMovePositionX;
        private float _maxMovePositionY;
        
        private Vector2 _direction;

        public event UnityAction<Asteroid, Vector2> Destroyed;

        [Inject]
        public void Construct(AsteroidData data)
        {
            Speed = data.Speed;
            _maxMovePositionX = data.MaxMovePositionX;
            _maxMovePositionY = data.MaxMovePositionY;
        }

        public void CalculateDirectionNormalized()
        {
            float positionX = Random.Range(-_maxMovePositionX, _maxMovePositionX);
            float positionY = Random.Range(-_maxMovePositionY, _maxMovePositionY);
            
            _direction = (new Vector3(positionX, positionY, 0) - transform.position).normalized;
        }

        protected override IEnumerator Move()
        {
            while (true)
            {
                Rigidbody.AddForce(Speed * Time.deltaTime * _direction);
                Rigidbody.velocity = Vector2.ClampMagnitude(Rigidbody.velocity, Speed);

                yield return null;
            }
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            Destroyed?.Invoke(this, transform.position);
        }
    }
}