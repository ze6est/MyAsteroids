using System;

namespace MyAsteroids.CodeBase.Data.Enemies.Pools
{
    [Serializable]
    public class AsteroidPoolData
    {
        public int Capacity = 10;
        public bool IsAutoExpand = true;
    }
}