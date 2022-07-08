using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TILab
{
    public class Gate : MonoBehaviour, CircuitItem
    {
        
        public InputPin[] Inputs { get; set; }
        
        public OutputPin[] Outputs { get; set; }

        protected virtual void Awake()
        {
            Inputs = GetComponentsInChildren<InputPin>();
            Outputs = GetComponentsInChildren<OutputPin>();
            
            this.OnCircuitUpdate();
        }

        void Update()
        {
            this.OnCircuitUpdate();
        }

        public virtual void OnCircuitUpdate()
        {
            if (Outputs == null) return;

            foreach (OutputPin output in Outputs)
            {
                output.OnCircuitUpdate();
            }
        }
    }
}
