using MyAsteroids.CodeBase.Data;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ammunitions
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Ammunition : MonoBehaviour
    {
        protected float StartSpeed;
        protected float MaxSpeed;
        
        private Rigidbody2D _rigidbody;

        [Inject]
        public abstract void Construct(GameData data);
        
        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();

        private void Update() => 
            Move();

        private void Move()
        {
            _rigidbody.AddRelativeForce(StartSpeed * Time.deltaTime * Vector2.up);
            _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, MaxSpeed);
        }
    }
}