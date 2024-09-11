using MyAsteroids.CodeBase.Data;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Ammunitions
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Ammunition : MonoBehaviour
    {
        protected GameData Data;
        
        protected float StartSpeed;
        protected float MaxSpeed;
        
        private Rigidbody2D _rigidbody;

        [Inject]
        protected void Construct(GameData data) => 
            Data = data;

        protected virtual void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();

        private void Update() => 
            Move();

        private void Move()
        {
            if (_rigidbody == null)
            {
                Debug.Log("Rb");
            }
            
            _rigidbody.AddRelativeForce(StartSpeed * Time.deltaTime * Vector2.up);
            _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, MaxSpeed);
        }
    }
}