using MyAsteroids.CodeBase.Data.Enemies;
using MyAsteroids.CodeBase.Data.Enemies.Pools;
using MyAsteroids.CodeBase.Enemies;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Pool.Enemies
{
    public class AsteroidSmallPool : ObjectsPool<AsteroidSmall>
    {
        public AsteroidSmallPool(AsteroidSmall prefab, Transform container, AsteroidSmallPoolData asteroidSmallPoolData, IInstantiator instantiator) 
            : base(prefab, container, asteroidSmallPoolData.IsAutoExpand, asteroidSmallPoolData.Capacity, instantiator)
        {
        }
    }
}