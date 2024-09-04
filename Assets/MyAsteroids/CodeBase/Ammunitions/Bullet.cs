using MyAsteroids.CodeBase.Data;
using UnityEngine;
using UnityEngine.Events;

namespace MyAsteroids.CodeBase.Ammunitions
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : Ammunition
    {
        public event UnityAction<Bullet> Destroyed;
        
        public override void Construct(GameData data)
        {
            StartSpeed = data.AmmunitionsData.BulletStartSpeed;
            MaxSpeed = data.AmmunitionsData.BulletMaxSpeed;
        }
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            Destroyed?.Invoke(this);
        }
    }
}