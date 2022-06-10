using System;
using System.Collections.Generic;
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

        private LineRenderer _lineRenderer;
        private List<Vector3> _bezierPoints = new List<Vector3>();
        
        public int vertexCount = 12;
        
        private void Start()
        {
            this._renderer = this.GetComponent<Renderer>();
            this._lineRenderer = this.GetComponent<LineRenderer>();
        }

        private void Awake()
        {
            this.UpdateBezier();
        }

        private void Update()
        {
            this.OnCircuitUpdate();
            this.UpdateBezier();
            this.DrawBezier();
        }

        private void UpdateBezier()
        {
            _bezierPoints = new List<Vector3>();

            var outputTransform = OutputPin.transform;
            var inputTransform = InputPin.transform;
            
            _bezierPoints.Add(outputTransform.position);
            Vector3 outputAxis = outputTransform.position + outputTransform.up;
            _bezierPoints.Add(outputAxis);
            
            Vector3 middle = (InputPin.transform.position + OutputPin.transform.position) / 2;
            float distance = Vector3.Distance(InputPin.transform.position, OutputPin.transform.position);
            Vector3 triangleTip = middle;// + (-Vector3.Cross(InputPin.transform.position, OutputPin.transform.position).normalized) * (distance * 0.2f);
            _bezierPoints.Add(Vector3.Lerp(outputAxis, triangleTip, 0.5f));
            _bezierPoints.Add(triangleTip);

            Vector3 inputAxis = inputTransform.position + inputTransform.up;
            _bezierPoints.Add(Vector3.Lerp(triangleTip, inputAxis, 0.5f));
            
            _bezierPoints.Add(inputAxis);
            _bezierPoints.Add(inputTransform.position);
        }

        private void DrawBezier()
        {
            var pointList = new List<Vector3>();
            for (int i = 2; i < _bezierPoints.Count; i+=2)
            {
                for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
                {
                    var tangentLineVertex1 = Vector3.Lerp(_bezierPoints[i-2], _bezierPoints[i-1], ratio);
                    var tangentLineVertex2 = Vector3.Lerp(_bezierPoints[i-1], _bezierPoints[i], ratio);
                    var bezierpoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
                    pointList.Add(bezierpoint);
                }
            }
            _lineRenderer.positionCount = pointList.Count;
            _lineRenderer.SetPositions(pointList.ToArray());
        }
        
        private void OnDrawGizmosSelected()
        {
            UpdateBezier();
            Gizmos.color = Color.green;
            for (int i = 1; i < _bezierPoints.Count; i++)
            {
                Gizmos.DrawLine(_bezierPoints[i-1], _bezierPoints[i]);
            }
            
            Gizmos.color = Color.red;
            for (int i = 2; i < _bezierPoints.Count; i++)
            {
                for (float ratio = 0.5f / vertexCount; ratio<1; ratio += 1.0f / vertexCount)
                {
                    Gizmos.DrawLine(Vector3.Lerp(_bezierPoints[i-2], _bezierPoints[i-1], ratio), Vector3.Lerp(_bezierPoints[i-1], _bezierPoints[i], ratio));
                }
            }
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(_bezierPoints[0], _bezierPoints[^1]);
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