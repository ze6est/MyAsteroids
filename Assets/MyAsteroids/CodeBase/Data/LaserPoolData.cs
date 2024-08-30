using System;

namespace MyAsteroids.CodeBase.Data
{
    [Serializable]
    public class LaserPoolData
    {
        public int Capacity = 10;
        public bool IsAutoExpand = false;
    }
}