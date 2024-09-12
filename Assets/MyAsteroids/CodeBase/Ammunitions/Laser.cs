using MyAsteroids.CodeBase.Logic;
using UnityEngine;
using UnityEngine.Events;

namespace MyAsteroids.CodeBase.Ammunitions
{
    public class Laser : Ammunition
    {
        public event UnityAction<Laser> Destroyed;
        
        protected override void Awake()
        {
            base.Awake();
            
            StartSpeed = Data.LaserStartSpeed;
            MaxSpeed = Data.LaserMaxSpeed;
        }
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out Destroyer _))
                Destroyed?.Invoke(this);
        }
    }
}