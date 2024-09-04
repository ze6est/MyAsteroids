using System.Collections;
using MyAsteroids.CodeBase.Data;
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
        public void Construct(GameData data) => 
            Speed = data.UfoData.Speed;

        public void Init(Transform target) => 
            _target = target;

        protected override IEnumerator Move()
        {
            while (true)
            {
                Vector2 direction = (_target.position - transform.position).normalized;
                Rigidbody.MovePosition(Rigidbody.position + Speed * Time.fixedDeltaTime * direction);

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