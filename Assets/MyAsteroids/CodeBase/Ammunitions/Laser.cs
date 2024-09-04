using MyAsteroids.CodeBase.Data;
using UnityEngine;
using UnityEngine.Events;

namespace MyAsteroids.CodeBase.Ammunitions
{
    public class Laser : Ammunition
    {
        public event UnityAction<Laser> Destroyed;
        
        public override void Construct(GameData data)
        {
            StartSpeed = data.AmmunitionsData.LaserStartSpeed;
            MaxSpeed = data.AmmunitionsData.LaserMaxSpeed;
        }
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out Destroyer _))
                Destroyed?.Invoke(this);
        }
    }
}