using System.Collections;
using MyAsteroids.CodeBase.Data.Enemies;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace MyAsteroids.CodeBase.Enemies
{
    public class AsteroidSmall : Enemie
    {
        private Vector2 _randomDirection;
        
        public event UnityAction<AsteroidSmall, Vector2> Destroyed;

        [Inject]
        public void Construct(AsteroidSmallData data)
        {
            Speed = data.Speed;
        }

        public void CalculateDirectionNormalized()
        {
            _randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }

        protected override IEnumerator Move()
        {
            while (true)
            {
                Rigidbody.AddForce(Speed * Time.deltaTime * _randomDirection);
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