using System;

namespace MyAsteroids.CodeBase.Data.Enemies
{
    [Serializable]
    public class AsteroidData
    {
        public float Speed = 0.5f;
        public float MaxMovePositionX = 2;
        public float MaxMovePositionY = 1;
    }
}