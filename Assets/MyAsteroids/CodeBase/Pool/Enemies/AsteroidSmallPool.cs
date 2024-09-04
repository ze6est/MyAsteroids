using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Enemies;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Pool.Enemies
{
    public class AsteroidSmallPool : ObjectsPool<AsteroidSmall>
    {
        public AsteroidSmallPool(AsteroidSmall prefab, Transform container, GameData data, IInstantiator instantiator) 
            : base(prefab, container, data.AsteroidSmallPoolData.IsAutoExpand, data.AsteroidSmallPoolData.Capacity, instantiator)
        {
        }
    }
}