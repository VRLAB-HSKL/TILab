using System;
using System.Collections.Generic;
using UnityEngine;

namespace TILab
{
    public class BaseCable : MonoBehaviour
    {
        public Vector3 BeginPos { get; set; }
        public Vector3 EndPos { get; set; }

        protected LineRenderer _lineRenderer;
        protected List<Vector3> _bezierPoints = new List<Vector3>();
        
        public int vertexCount = 12;
        
        protected virtual void Start()
        {
            this._lineRenderer = this.GetComponent<LineRenderer>();
        }

        protected virtual void Awake()
        {
            this.UpdateBezier();
        }

        protected virtual void Update()
        {
            this.UpdateBezier();
            this.DrawBezier();
        }

        protected virtual void UpdateBezier()
        {
            _bezierPoints = new List<Vector3>();
            
            
            _bezierPoints.Add(BeginPos);
            _bezierPoints.Add(Vector3.Lerp(BeginPos, EndPos, 0.5f));
            _bezierPoints.Add(EndPos);
        }

        protected virtual void DrawBezier()
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
        
        protected virtual void OnDrawGizmos()
        {
            UpdateBezier();
            Gizmos.color = Color.green;
            for (int i = 1; i < _bezierPoints.Count; i++)
            {
                Gizmos.DrawLine(transform.TransformPoint(_bezierPoints[i-1]), transform.TransformPoint(_bezierPoints[i]));
            }
            
            Gizmos.color = Color.red;
            for (int i = 2; i < _bezierPoints.Count; i++)
            {
                for (float ratio = 0.5f / vertexCount; ratio<1; ratio += 1.0f / vertexCount)
                {
                    Gizmos.DrawLine(Vector3.Lerp(transform.TransformPoint(_bezierPoints[i-2]), transform.TransformPoint(_bezierPoints[i-1]), ratio), Vector3.Lerp(transform.TransformPoint(_bezierPoints[i-1]), transform.TransformPoint(_bezierPoints[i]), ratio));
                }
            }
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.TransformPoint(_bezierPoints[0]), transform.TransformPoint(_bezierPoints[_bezierPoints.Count-1]));
        }
    }
}