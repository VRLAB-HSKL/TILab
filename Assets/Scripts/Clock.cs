using System;
using UnityEngine;

namespace TILab
{
    public class Clock : MonoBehaviour
    {
        public GameObject Finger;
        public float Speed = 1;
        
        private OutputPin OutputPin;
        private float _counter = 0;

        private void Start()
        {
            OutputPin = GetComponentInChildren<OutputPin>();
        }
        
        private void FixedUpdate()
        {
            Finger.transform.Rotate(0, Speed, 0);

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