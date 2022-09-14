using ASAP.SignalsSystem;
using ASAP.Signals;
using Zenject;

namespace ASAP.Installers
{
    public class SignalSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.Bind<ISignalSystem>().To<SignalSystem>().AsSingle();
            BindSignals();
        }

        private void BindSignals()
        {
            Container.DeclareSignal<OnASAPModeEnabledSignal>();
            Container.DeclareSignal<OnASAPModeDisabledSignal>();
        }
    }
}