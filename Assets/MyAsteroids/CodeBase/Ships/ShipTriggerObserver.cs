using MyAsteroids.CodeBase.Enemies;
using UnityEngine;
using UnityEngine.Events;

namespace MyAsteroids.CodeBase.Ships
{
    public class ShipTriggerObserver : MonoBehaviour
    {
        public event UnityAction Died;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Enemie>(out _))
                Died?.Invoke();
        }

    }
}