using System;
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;
using UnityEngine.Serialization;

namespace TILab
{
    public class Button : MonoBehaviour
    {
        public OutputPin OutputPin { get; set; }
        public GameObject ButtonTop;
        public Vector3 ButtonClickOffset = new Vector3(0, -0.05f, 0);

        private void Start()
        {
            OutputPin = GetComponentInChildren<OutputPin>();
        }

        public virtual void Activate()
        {
            OutputPin.OnCircuitUpdate();
            ButtonTop.transform.position += ButtonClickOffset;
        }

        public virtual void Deactivate()
        {
            OutputPin.OnCircuitUpdate();
            ButtonTop.transform.position -= ButtonClickOffset;
        }
    }
}