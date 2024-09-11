using UnityEngine;
using UnityEngine.Events;

namespace MyAsteroids.CodeBase.Ammunitions
{
    public class Bullet : Ammunition
    {
        public event UnityAction<Bullet> Destroyed;

        protected override void Awake()
        {
            base.Awake();
            
            StartSpeed = Data.AmmunitionsData.BulletStartSpeed;
            MaxSpeed = Data.AmmunitionsData.BulletMaxSpeed;
        }
        
        protected void OnTriggerEnter2D(Collider2D other) => 
            Destroyed?.Invoke(this);
    }
}