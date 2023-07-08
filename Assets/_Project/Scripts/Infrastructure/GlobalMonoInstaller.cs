using GMTK.Game.Core;
using Zenject;

namespace GMTK.Infrastructure
{
    public class GlobalMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.Bind<IGameManager>().To<GameManager>().AsSingle().NonLazy();
            Container.Bind<IManaTimer>().To<ManaTimer>().AsSingle().NonLazy();
        }
    }
}