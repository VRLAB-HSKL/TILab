using System;
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;

namespace TILab
{
    public class Button : MonoBehaviour, IColliderEventPressEnterHandler, IColliderEventPressExitHandler
    {
        public OutputPin OutputPin { get; set; }
        public GameObject ButtonTop;
        public Vector3 ButtonClickOffset = new Vector3(0, -0.05f, 0);
        
        private void Start()
        {
            OutputPin = GetComponentInChildren<OutputPin>();
        }


        public virtual void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            OutputPin.OnCircuitUpdate();
            ButtonTop.transform.position += ButtonClickOffset;
        }

        public virtual void OnColliderEventPressExit(ColliderButtonEventData eventData)
        {
            OutputPin.OnCircuitUpdate();
            ButtonTop.transform.position -= ButtonClickOffset;
        }
    }
}