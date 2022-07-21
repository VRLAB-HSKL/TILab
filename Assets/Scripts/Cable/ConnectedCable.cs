using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace TILab
{
    public class ConnectedCable : BaseCable, CircuitItem
    {
        [field: SerializeField] 
        public InputPin InputPin { get; set; }
        
        [field: SerializeField] 
        public OutputPin OutputPin { get; set; }

        public bool deletable = true;

        private bool _value = false;
        private Renderer _renderer;
        private MeshCollider _collider;
        private Mesh _mesh;
        
        protected override void Start()
        {
            base.Start();
            _renderer = this.GetComponent<Renderer>();
            _collider = this.GetComponent<MeshCollider>();
            _mesh = new Mesh(); 

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
            
            _bezierPoints.Add(transform.InverseTransformPoint(InputPin.transform.position));

            float distance = Mathf.Abs((InputPin.transform.position - OutputPin.transform.position).magnitude);

            if (distance > 2f)
            {
                
                Vector3 inputAxisDistance = CalculatePinCableDistance(InputPin, OutputPin);
                Vector3 outputAxis = transform.InverseTransformPoint(InputPin.transform.position + inputAxisDistance);
                // Vector3 outputAxis = transform.InverseTransformPoint(InputPin.transform.position + InputPin.transform.up);
                _bezierPoints.Add(outputAxis);
            
            
                Vector3 outputAxisDistance = CalculatePinCableDistance(OutputPin, InputPin);
                Vector3 inputAxis = transform.InverseTransformPoint(OutputPin.transform.position + outputAxisDistance);
                // Vector3 inputAxis = transform.InverseTransformPoint(OutputPin.transform.position + OutputPin.transform.up);
                Vector3 axisMiddle = Vector3.Lerp(outputAxis, inputAxis, 0.5f);
                _bezierPoints.Add(axisMiddle);
            
                _bezierPoints.Add(inputAxis);
            }
            else
            {
                Vector3 middle = transform.InverseTransformPoint(Vector3.Lerp(InputPin.transform.position,
                    OutputPin.transform.position, 0.5f));
                Vector3 tip = middle +
                              (-Vector3.Cross(InputPin.transform.position, OutputPin.transform.position).normalized) *
                              (distance * 0.2f);
                
                // _bezierPoints.Add(Vector3.Lerp(transform.InverseTransformPoint(InputPin.transform.position), middle, 0.5f));
                // _bezierPoints.Add(middle);
                _bezierPoints.Add(tip);
                // _bezierPoints.Add(Vector3.Lerp(transform.InverseTransformPoint(OutputPin.transform.position), middle, 0.5f));
            }
            
            _bezierPoints.Add(transform.InverseTransformPoint(OutputPin.transform.position));
        }

        protected override void DrawBezier()
        {
            base.DrawBezier();
            if (_collider)
            {
                _lineRenderer.useWorldSpace = false;
                transform.position = transform.TransformPoint(_bezierPoints[_bezierPoints.Count / 2]);
                _lineRenderer.BakeMesh(_mesh);
                _collider.sharedMesh = _mesh;
            }
            
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

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.TransformPoint(_bezierPoints[_bezierPoints.Count / 2]), 0.05f);
        }

        private Vector3 CalculatePinCableDistance(Pin a, Pin b)
        {
            Vector3 distance = a.transform.position - b.transform.position;
            Vector3 scaledDistance = Vector3.Scale(distance, a.transform.up);
            Vector3 absScaledDistance = new Vector3(Mathf.Abs(scaledDistance.x), Mathf.Abs(scaledDistance.y),
                Mathf.Abs(scaledDistance.z));
            Vector3 cappedScaledDistance = Vector3.Min(absScaledDistance, Vector3.one);

            return a.transform.up * cappedScaledDistance.magnitude;
        }

        protected void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            foreach (var point in _bezierPoints)
            {
                Gizmos.DrawSphere(transform.TransformPoint(point), 0.08f);
            }
        }

        public void OnDestroy()
        {
            InputPin.Disconnect(this);
            OutputPin.Disconnect(this);
        }
    }
}