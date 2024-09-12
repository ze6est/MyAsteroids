using System;

namespace MyAsteroids.CodeBase.Data.Ammunitions
{
    [Serializable]
    public class LaserPoolData : IData
    {
        public int Capacity = 10;
        public bool IsAutoExpand = false;
    }
}