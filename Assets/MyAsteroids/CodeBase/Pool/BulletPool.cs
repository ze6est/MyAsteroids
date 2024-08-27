using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Pool
{
    public class BulletPool : ObjectsPool<Bullet>
    {
        public BulletPool(Bullet prefab, Transform container, BulletPoolData bulletPoolData, IInstantiator instantiator) : 
            base(prefab, container, bulletPoolData.IsAutoExpand, bulletPoolData.Capacity, instantiator) {}
    }
}