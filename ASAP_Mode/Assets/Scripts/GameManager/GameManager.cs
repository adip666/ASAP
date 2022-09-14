using System;
using System.Collections.Generic;
using ASAP.SignalsSystem;
using ASAP.Signals;
using ASAPInteractions;
using UnityEngine;
using Zenject;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        private ISignalSystem signalSystem;
        private List<IASAPInteractableObjects> interactableObjects;

        private int modeMaxTime = 5;
        private float currentModeTime = 0;
        private bool isTimeMode;
        [Inject]
        private void Inject(ISignalSystem signalSystem, List<IASAPInteractableObjects> interactableObjects)
        {
            this.signalSystem = signalSystem;
            this.interactableObjects = interactableObjects;
        }
        private void Start()
        {
            SubscribeSignals();
        }

        private void SubscribeSignals()
        {
            signalSystem.SubscribeSignal<OnASAPModeEnabledSignal>(OnASAPModeEnabled);
        }
        
        private void UnSubscribeSignals()
        {
            signalSystem.UnsubscribeSignal<OnASAPModeEnabledSignal>(OnASAPModeEnabled);
        }

        private void OnDestroy()
        {
            UnSubscribeSignals();
        }

        private void OnASAPModeEnabled()
        {
            foreach (var interactable in interactableObjects)
            {
                interactable.ChangeMovementSpeed(.8f);
            }
            
            isTimeMode = true;
        }

        private void FixedUpdate()
        {
            foreach (var interactable in interactableObjects)
            {
                interactable.FixedTick();
            }

          
          
        }

        private void Update()
        {
            if (isTimeMode)
            {
                currentModeTime += Time.deltaTime;
                if (currentModeTime > modeMaxTime)
                {
                    DisableTimeMode();
                }
                
            }
        }

        private void DisableTimeMode()
        {
            isTimeMode = false;
            currentModeTime = 0;
            
            foreach (var interactable in interactableObjects)
            {
                interactable.ChangeMovementSpeed(1);
            }
            signalSystem.FireSignal<OnASAPModeDisabledSignal>();
        }
        
        
    }
}