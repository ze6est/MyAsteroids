using MyAsteroids.CodeBase.Data.Enemies;
using MyAsteroids.CodeBase.Data.Enemies.Pools;
using MyAsteroids.CodeBase.Enemies;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Pool.Enemies
{
    public class UfoPool : ObjectsPool<Ufo>
    {
        public UfoPool(Ufo prefab, Transform container, UfoPoolData ufoPoolData, IInstantiator instantiator) 
            : base(prefab, container, ufoPoolData.IsAutoExpand, ufoPoolData.Capacity, instantiator)
        {
        }
    }
}