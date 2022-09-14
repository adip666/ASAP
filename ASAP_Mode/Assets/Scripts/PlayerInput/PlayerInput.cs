using ASAP.SignalsSystem;
using ASAP.Signals;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ASAP.Inputs
{
    public class PlayerInput : StarterAssetsInputs
    {
        [Header("ASAP Mode")] [SerializeField] private bool asapMode;

        private ISignalSystem signalSystem;

        [Inject]
        private void Inject(ISignalSystem signalSystem)
        {
            this.signalSystem = signalSystem;
        }


        private void ASAPModeInput(bool asapMode)
        {
            this.asapMode = asapMode;
        }

        public void OnASAPMode(InputValue value)
        {
            ASAPModeInput(value.isPressed);
            if (value.isPressed)
            {
                signalSystem.FireSignal<OnASAPModeEnabledSignal>();
            }
        }
    }
}