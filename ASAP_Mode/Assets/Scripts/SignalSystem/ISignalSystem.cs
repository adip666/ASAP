using System;

namespace ASAP.SignalsSystem
{
    public interface ISignalSystem
    {
        void SubscribeSignal<T>(Action onFire) where T : ICustomSignal;

        void SubscribeSignal<T>(Action<T> onFire) where T : ICustomSignal;

        void UnsubscribeSignal<T>(Action onFire) where T : ICustomSignal;

        void UnsubscribeSignal<T>(Action<T> onFire) where T : ICustomSignal;

        void FireSignal<T>() where T : ICustomSignal;

        void FireSignal<T>(T signal) where T : ICustomSignal;
    }
}