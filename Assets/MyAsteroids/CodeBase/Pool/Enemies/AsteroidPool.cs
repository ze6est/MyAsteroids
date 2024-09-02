using MyAsteroids.CodeBase.Data.Enemies;
using MyAsteroids.CodeBase.Data.Enemies.Pools;
using MyAsteroids.CodeBase.Enemies;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Pool.Enemies
{
    public class AsteroidPool : ObjectsPool<Asteroid>
    {
        public AsteroidPool(Asteroid prefab, Transform container, AsteroidPoolData asteroidPoolData, IInstantiator instantiator) 
            : base(prefab, container, asteroidPoolData.IsAutoExpand, asteroidPoolData.Capacity, instantiator)
        {
        }
    }
}