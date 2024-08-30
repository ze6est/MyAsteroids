using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Pool
{
    public class LaserPool : ObjectsPool<Laser>
    {
        public LaserPool(Laser prefab, Transform container, LaserPoolData laserPoolData, IInstantiator instantiator) : 
            base(prefab, container, laserPoolData.IsAutoExpand, laserPoolData.Capacity, instantiator) {}
    }
}