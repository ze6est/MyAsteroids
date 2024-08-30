using MyAsteroids.CodeBase.Data;
using UnityEngine;
using UnityEngine.Events;

namespace MyAsteroids.CodeBase.Ammunitions
{
    public class Laser : Ammunition
    {
        public event UnityAction<Laser> Destroyed;
        
        public override void Construct(AmmunitionsData ammunitionsData)
        {
            StartSpeed = ammunitionsData.LaserStartSpeed;
            MaxSpeed = ammunitionsData.LaserMaxSpeed;
        }
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            Destroyed?.Invoke(this);
        }
    }
}