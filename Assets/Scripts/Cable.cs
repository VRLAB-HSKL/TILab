using System;
using UnityEngine;

namespace TILab
{
    public class Cable : MonoBehaviour, CircuitItem
    {
        [field: SerializeField] 
        public InputPin InputPin { get; set; }
        
        [field: SerializeField] 
        public OutputPin OutputPin { get; set; }

        private bool _value = false;

        private Renderer _renderer;
        
        private void Start()
        {
            this._renderer = this.GetComponent<Renderer>();
        }

        private void Update()
        {
            this.OnCircuitUpdate();
        }

        public void OnCircuitUpdate()
        {
            if (InputPin != null)
            {
                InputPin.Value = _value;
                InputPin.OnCircuitUpdate();
            }
            
            if (OutputPin != null)
            {
                _value = OutputPin.Value;
                
                var color = _value ? Color.green : Color.red;
                _renderer.material.color = color;
            }
        }
    }
}