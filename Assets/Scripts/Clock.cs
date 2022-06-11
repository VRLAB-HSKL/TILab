using System;
using UnityEngine;

namespace TILab
{
    public class Clock : MonoBehaviour
    {
        public GameObject Finger;
        public GameObject CenterPoint;
        public float Speed = 1;
        
        private OutputPin OutputPin;
        private float _counter = 0;

        private void Start()
        {
            OutputPin = GetComponentInChildren<OutputPin>();
        }
        
        private void FixedUpdate()
        {
            Finger.transform.RotateAround(CenterPoint.transform.position, CenterPoint.transform.up, Speed);

            _counter += Speed;
            if (_counter >= 360)
            {
                _counter = 0;
                OutputPin.Value = !OutputPin.Value;
                OutputPin.OnCircuitUpdate();
            }
        }
    }
}