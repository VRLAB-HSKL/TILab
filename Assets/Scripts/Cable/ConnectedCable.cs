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
        
        protected override void Start()
        {
            base.Start();
            this._renderer = this.GetComponent<Renderer>();
            this._collider = this.GetComponent<MeshCollider>();

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
            Vector3 outputAxis = transform.InverseTransformPoint(InputPin.transform.position + InputPin.transform.up);
            _bezierPoints.Add(outputAxis);
            
            Vector3 inputAxis = transform.InverseTransformPoint(OutputPin.transform.position + OutputPin.transform.up);
            Vector3 axisMiddle = Vector3.Lerp(outputAxis, inputAxis, 0.5f);
            _bezierPoints.Add(axisMiddle);
            
            _bezierPoints.Add(inputAxis);
            _bezierPoints.Add(transform.InverseTransformPoint(OutputPin.transform.position));
        }

        protected override void DrawBezier()
        {
            base.DrawBezier();
            if (_collider)
            {
                Mesh mesh = new Mesh();
                List<Vector3> newPoints = new List<Vector3>();
                _lineRenderer.useWorldSpace = false;
                transform.position = transform.TransformPoint(_bezierPoints[_bezierPoints.Count / 2]);
                _lineRenderer.BakeMesh(mesh);
                _collider.sharedMesh = mesh;
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
    }
}