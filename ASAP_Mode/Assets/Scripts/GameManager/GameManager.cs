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
        [SerializeField]private float asapModeSpeed = .8f;
        
        private ISignalSystem signalSystem;
        private List<IASAPInteractableObjects> interactableObjects;
        private int modeMaxTime = 5;
        private float currentModeTime = 0f;
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
            InitializeObjects();
        }

        private void InitializeObjects()
        {
            foreach (var interactable in interactableObjects)
            {
                interactable.Initialize();
            }
        }
        
        private void SubscribeSignals()
        {
            signalSystem.SubscribeSignal<OnASAPModeEnabledSignal>(OnASAPModeEnabled);
        }
        
        private void UnsubscribeSignals()
        {
            signalSystem.UnsubscribeSignal<OnASAPModeEnabledSignal>(OnASAPModeEnabled);
        }

       

        private void OnASAPModeEnabled()
        {
            if(isTimeMode)
                return;;
            
            foreach (var interactable in interactableObjects)
            {
                interactable.ChangeMovementSpeed(asapModeSpeed);
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
                interactable.ResetSpeed();
            }
            signalSystem.FireSignal<OnASAPModeDisabledSignal>();
        }
        
        private void OnDestroy()
        {
            UnsubscribeSignals();
        }
        
        
    }
}