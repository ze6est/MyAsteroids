using UnityEngine;

namespace MyAsteroids.CodeBase.Enemies
{
    public abstract class Enemie : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D Rigidbody;
        
        protected float Speed;
        
        protected abstract void Move();

        protected abstract void OnTriggerEnter2D(Collider2D other);
    }
}