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

        private void Awake()
        {
            Inputs = GetComponentsInChildren<InputPin>();
            Outputs = GetComponentsInChildren<OutputPin>();
        }

        // Update is called once per frame
        void Update()
        {
            this.OnCircuitUpdate();
            Debug.Log(Inputs.Length);
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
