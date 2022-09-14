using System;
using Zenject;

namespace ASAP.SignalsSystem
{
    public class SignalSystem : ISignalSystem
    {
        private readonly SignalBus signalBus;

        public SignalSystem(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public void SubscribeSignal<T>(Action onFire) where T : ICustomSignal
        {
            signalBus.Subscribe<T>(onFire);
        }

        public void SubscribeSignal<T>(Action<T> onFire) where T : ICustomSignal
        {
            signalBus.Subscribe(onFire);
        }

        public void UnsubscribeSignal<T>(Action onFire) where T : ICustomSignal
        {
            signalBus.TryUnsubscribe<T>(onFire);
        }

        public void UnsubscribeSignal<T>(Action<T> onFire) where T : ICustomSignal
        {
            signalBus.TryUnsubscribe(onFire);
        }

        public void FireSignal<T>() where T : ICustomSignal
        {
            signalBus.Fire<T>();
        }

        public void FireSignal<T>(T signal) where T : ICustomSignal
        {
            signalBus.Fire(signal);
        }
    }
}