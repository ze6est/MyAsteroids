using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Enemies;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Pool.Enemies
{
    public class AsteroidPool : ObjectsPool<Asteroid>
    {
        public AsteroidPool(Asteroid prefab, Transform container, GameData data, IInstantiator instantiator) 
            : base(prefab, container, data.AsteroidPoolData.IsAutoExpand, data.AsteroidPoolData.Capacity, instantiator)
        {
        }
    }
}