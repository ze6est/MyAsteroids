using MyAsteroids.CodeBase.Inputs;
using MyAsteroids.CodeBase.Ships;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class ShipInstaller : MonoInstaller
    {
        [SerializeField] private Ship _shipPrefab;

        public override void InstallBindings()
        {
            Container.Bind<ShipInputs>().AsSingle();
            
            Container.Bind<Ship>().FromComponentInNewPrefab(_shipPrefab).AsSingle();
        }
    }
}