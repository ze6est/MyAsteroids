using System;

namespace MyAsteroids.CodeBase.Data.Enemies.Pools
{
    [Serializable]
    public class AsteroidSmallPoolData
    {
        public int Capacity = 15;
        public bool IsAutoExpand = true;
    }
}