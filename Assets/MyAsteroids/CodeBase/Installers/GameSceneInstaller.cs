using MyAsteroids.CodeBase.UI;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private ShipHUD _shipHUD;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle().WithArguments(_shipHUD);
        }
    }
}
