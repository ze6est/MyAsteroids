using System;

namespace MyAsteroids.CodeBase.Data.Enemies.Pools
{
    [Serializable]
    public class UfoPoolData : IData
    {
        public int Capacity = 10;
        public bool IsAutoExpand = true;
    }
}