using MyAsteroids.CodeBase.UI;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private ShipHUD _shipHUD;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_shipHUD);
            Container.Bind<EntryPoint>().AsSingle().NonLazy();
            Container.Bind<ScoreCounter>().AsSingle().NonLazy();
        }
    }
}