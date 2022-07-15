using System;
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;
using UnityEngine.Serialization;

namespace TILab
{
    public class Button : MonoBehaviour, IColliderEventPressEnterHandler, IColliderEventPressExitHandler
    {
        public OutputPin OutputPin { get; set; }
        public ButtonTop buttonTop;
        public Vector3 ButtonClickOffset = new Vector3(0, -0.05f, 0);

        protected bool _buttonTopCollided = false;
        
        private void Start()
        {
            OutputPin = GetComponentInChildren<OutputPin>();
            
            buttonTop.RegisterEnterCallback(OnButtonTopTriggerEnter);
            buttonTop.RegisterExitCallback(OnButtonTopTriggerExit);
        }

        void OnButtonTopTriggerEnter()
        {
            Debug.Log("OnButtonTopTriggerEnter");
            _buttonTopCollided = true;
        }

        private void OnButtonTopTriggerExit()
        {
            Debug.Log("OnButtonTopTriggerExit");
            _buttonTopCollided = false;
        }

        public virtual void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            if (eventData.button != Config.ButtonActivationButton) return;
            if (!_buttonTopCollided) return;
            
            OutputPin.OnCircuitUpdate();
            buttonTop.transform.position += ButtonClickOffset;
        }

        public virtual void OnColliderEventPressExit(ColliderButtonEventData eventData)
        {
            if (eventData.button != Config.ButtonActivationButton) return;
            if (!_buttonTopCollided) return;
            
            OutputPin.OnCircuitUpdate();
            buttonTop.transform.position -= ButtonClickOffset;
        }
    }
}