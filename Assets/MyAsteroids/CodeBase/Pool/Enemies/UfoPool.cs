using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Enemies;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Pool.Enemies
{
    public class UfoPool : ObjectsPool<Ufo>
    {
        public UfoPool(Ufo prefab, Transform container, GameData data, IInstantiator instantiator) 
            : base(prefab, container, data.UfoPoolData.IsAutoExpand, data.UfoPoolData.Capacity, instantiator)
        {
        }
    }
}