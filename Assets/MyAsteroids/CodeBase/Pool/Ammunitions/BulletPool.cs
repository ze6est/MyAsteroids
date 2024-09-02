using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data.Ammunitions;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Pool.Ammunitions
{
    public class BulletPool : ObjectsPool<Bullet>
    {
        public BulletPool(Bullet prefab, Transform container, BulletPoolData bulletPoolData, IInstantiator instantiator) : 
            base(prefab, container, bulletPoolData.IsAutoExpand, bulletPoolData.Capacity, instantiator) {}
    }
}