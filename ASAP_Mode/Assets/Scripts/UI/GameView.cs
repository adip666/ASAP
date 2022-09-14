using ASAP.Signals;
using ASAP.SignalsSystem;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Image asapModeImage;
        [Inject] private ISignalSystem signalSystem;

        private void Start()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            signalSystem.SubscribeSignal<OnASAPModeEnabledSignal>(OnModeEnabled);
            signalSystem.SubscribeSignal<OnASAPModeDisabledSignal>(OnModeDisabled);
        }

        private void OnModeEnabled(OnASAPModeEnabledSignal signal)
        {
            asapModeImage.gameObject.SetActive(true);
        }
        private void OnModeDisabled(OnASAPModeDisabledSignal signal)
        {
            asapModeImage.gameObject.SetActive(false);
        }
        
        private void Unsubscribe()
        {
            signalSystem.UnsubscribeSignal<OnASAPModeEnabledSignal>(OnModeEnabled);
            signalSystem.UnsubscribeSignal<OnASAPModeDisabledSignal>(OnModeDisabled);
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}