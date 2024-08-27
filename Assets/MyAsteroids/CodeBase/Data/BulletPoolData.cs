using System;

namespace MyAsteroids.CodeBase.Data
{
    [Serializable]
    public class BulletPoolData
    {
        public int Capacity;
        public bool IsAutoExpand;
    }
}