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
        private Vector3 triangleTip;
        
        public int vertexCount = 12;
        
        private void Start()
        {
            this._renderer = this.GetComponent<Renderer>();
            this._lineRenderer = this.GetComponent<LineRenderer>();
            
            // UpdateLine();
        }

        private void Update()
        {
            Vector3 middle = (InputPin.transform.position + OutputPin.transform.position) / 2;
            float distance = Vector3.Distance(InputPin.transform.position, OutputPin.transform.position);
            triangleTip = middle + (Vector3.Cross(InputPin.transform.position, OutputPin.transform.position).normalized) * (distance * 0.33f);
            this.OnCircuitUpdate();
            this.DrawBezier();
        }

        private void UpdateLine()
        {
            if (InputPin != null && OutputPin != null)
            {
                _lineRenderer.SetPosition(0, OutputPin.transform.position);
                _lineRenderer.SetPosition(1, InputPin.transform.position);
            }
        }

        private void DrawBezier()
        {
            var pointList = new List<Vector3>();
            for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
            {
                var tangentLineVertex1 = Vector3.Lerp(OutputPin.transform.position, triangleTip, ratio);
                var tangentLineVertex2 = Vector3.Lerp(triangleTip, InputPin.transform.position, ratio);
                var bezierpoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
                pointList.Add(bezierpoint);
            }
            _lineRenderer.positionCount = pointList.Count;
            _lineRenderer.SetPositions(pointList.ToArray());
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(OutputPin.transform.position, triangleTip);

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(triangleTip, InputPin.transform.position);

            Gizmos.color = Color.red;
            for (float ratio = 0.5f / vertexCount; ratio<1; ratio += 1.0f / vertexCount)
            {
                Gizmos.DrawLine(Vector3.Lerp(OutputPin.transform.position, triangleTip, ratio), Vector3.Lerp(triangleTip, InputPin.transform.position, ratio));
            }
            Gizmos.DrawSphere(triangleTip, 0.1f);
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