using System.Collections;
using UnityEngine;

namespace MyAsteroids.CodeBase.Enemies
{
    public abstract class Enemie : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D Rigidbody;
        
        protected float Speed;
        
        private Coroutine _move;
        
        public void StartMove() => 
            _move = StartCoroutine(Move());

        protected abstract IEnumerator Move();

        protected virtual void OnTriggerEnter2D(Collider2D other) => 
            StopCoroutine(_move);
    }
}