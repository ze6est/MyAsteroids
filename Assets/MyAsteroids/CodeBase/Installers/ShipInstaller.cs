using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Data.Ammunitions;
using MyAsteroids.CodeBase.Factories;
using MyAsteroids.CodeBase.Inputs;
using MyAsteroids.CodeBase.Ships;
using MyAsteroids.CodeBase.UI;
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

            Container.Bind<ShipFactory>().AsSingle().WithArguments(_shipPrefab).NonLazy();
        }
    }
}