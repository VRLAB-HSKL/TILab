using System;
using UnityEngine;

namespace TILab
{
    public class CircuitDoor : MonoBehaviour, CircuitItem
    {
        private Door _door;
        private InputPin _pin;


        public void Start()
        {
            _door = GetComponentInChildren<Door>();
            _pin = GetComponentInChildren<InputPin>();

            if (_door == null || _pin == null)
            {
                throw new NotImplementedException("CircuitDoor requirements not met");
            }

            _door.active = false;
        }
        
        public void OnCircuitUpdate()
        {
            _door.active = _pin.Value;
        }

        public void FixedUpdate()
        {
            OnCircuitUpdate();
        }
    }
}