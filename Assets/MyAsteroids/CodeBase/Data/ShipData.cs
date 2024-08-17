using System;
using UnityEngine;

namespace MyAsteroids.CodeBase.Data
{
    [Serializable]
    public class ShipData
    {
        [Header("Ship Mover")] 
        public float Acceleration = 200f;
        public float Deceleration = 0.5f;
        public float MaxSpeed = 4f;

        [Header("ShipRotator")] 
        public float RotateSpeed = 1.5f;
    }
}