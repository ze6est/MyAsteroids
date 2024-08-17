using MyAsteroids.CodeBase.Ships;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Factories
{
    public class ShipFactory : IFactory<Ship>
    {
        private readonly DiContainer _diContainer;
        private readonly Ship _ship;
        
        public ShipFactory(DiContainer diContainer, Ship ship)
        {
            _diContainer = diContainer;
            _ship = ship;
        }

        public Ship Create()
        {
            Debug.Log("Create Ship");
            return _diContainer.InstantiatePrefabForComponent<Ship>(_ship);
        }
    }
}