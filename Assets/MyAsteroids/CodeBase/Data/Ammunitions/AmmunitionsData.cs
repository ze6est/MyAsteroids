using System;
using UnityEngine;

namespace MyAsteroids.CodeBase.Data.Ammunitions
{
    [Serializable]
    public class AmmunitionsData
    {
        [Header("Bullets")] 
        public float BulletStartSpeed = 10f;
        public float BulletMaxSpeed = 15f;
        
        [Header("Lasers")]
        public float LaserStartSpeed = 5f;
        public float LaserMaxSpeed = 10f;
    }
}