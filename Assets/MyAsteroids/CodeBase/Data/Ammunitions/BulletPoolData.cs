using System;

namespace MyAsteroids.CodeBase.Data.Ammunitions
{
    [Serializable]
    public class BulletPoolData : IData
    {
        public int Capacity = 20;
        public bool IsAutoExpand = true;
    }
}