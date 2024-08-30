using MyAsteroids.CodeBase.Data;
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
        [SerializeField] private ShipData _shipData;

        [SerializeField] private BulletPoolData _bulletPoolData;
        [SerializeField] private LaserPoolData _laserPoolData;
        [SerializeField] private AmmunitionsData _ammunitionsData;

        public override void InstallBindings()
        {
            Container.BindInstance(_shipData);

            Container.BindInstance(_bulletPoolData);
            Container.BindInstance(_laserPoolData);
            Container.BindInstance(_ammunitionsData);

            Container.Bind<ShipInputs>().AsSingle();

            Container.Bind<ShipFactory>().AsSingle().WithArguments(_shipPrefab);
        }
    }
}