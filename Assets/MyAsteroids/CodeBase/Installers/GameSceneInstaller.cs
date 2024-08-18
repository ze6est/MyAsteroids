using Zenject;

namespace MyAsteroids.CodeBase.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle();
        }
    }
}
