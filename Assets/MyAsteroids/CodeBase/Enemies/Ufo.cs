using MyAsteroids.CodeBase.Data.Enemies;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace MyAsteroids.CodeBase.Enemies
{
    public class Ufo : Enemie
    {
        private Transform _target;
        
        public event UnityAction<Ufo, Vector2> Destroyed;
        
        [Inject]
        public void Construct(UfoData data) => 
            Speed = data.Speed;

        public void Init(Transform target)
        {
            _target = target;
        }

        private void Update() => 
            Move();

        protected override void Move()
        {
            Vector2 direction = (_target.position - transform.position).normalized;
            Rigidbody.MovePosition(Rigidbody.position + Speed * Time.fixedDeltaTime * direction);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            Destroyed?.Invoke(this, transform.position);
        }
    }
}