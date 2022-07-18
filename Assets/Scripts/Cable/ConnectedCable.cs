using System.Collections.Generic;
using UnityEngine;

namespace TILab
{
    public class ConnectedCable : BaseCable, CircuitItem
    {
        [field: SerializeField] 
        public InputPin InputPin { get; set; }
        
        [field: SerializeField] 
        public OutputPin OutputPin { get; set; }

        private bool _value = false;
        private Renderer _renderer;

        protected override void Start()
        {
            base.Start();
            this._renderer = this.GetComponent<Renderer>();

            BeginPos = InputPin.transform.position;
            EndPos = OutputPin.transform.position;
        }
        
        protected override void Update()
        {
            if (InputPin == null || OutputPin == null) return;
            this.OnCircuitUpdate();
            base.Update();
        }

        protected override void UpdateBezier()
        {
            if (InputPin == null || OutputPin == null) return;
            _bezierPoints = new List<Vector3>();
            
            _bezierPoints.Add(InputPin.transform.position);
            Vector3 outputAxis = InputPin.transform.position + InputPin.transform.up;
            _bezierPoints.Add(outputAxis);
            
            Vector3 inputAxis = OutputPin.transform.position + OutputPin.transform.up;
            Vector3 axisMiddle = Vector3.Lerp(outputAxis, inputAxis, 0.5f);
            _bezierPoints.Add(axisMiddle);
            
            _bezierPoints.Add(inputAxis);
            _bezierPoints.Add(OutputPin.transform.position);
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

        protected override void OnDrawGizmos()
        {
            if (InputPin == null || OutputPin == null) return;
            base.OnDrawGizmos();
        }
    }
}