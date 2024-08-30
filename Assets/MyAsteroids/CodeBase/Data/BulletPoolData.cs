using System;

namespace MyAsteroids.CodeBase.Data
{
    [Serializable]
    public class BulletPoolData
    {
        public int Capacity = 20;
        public bool IsAutoExpand = true;
    }
}