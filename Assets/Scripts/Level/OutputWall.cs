using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TILab
{
    public class OutputWall : MonoBehaviour, CircuitItem
    {
        public InputPin input { get; set; }
        public OutputPin[] Outputs { get; set; }
        int counter { get; set; }
        int numberOfStates { get; set; }

        protected virtual void Awake()
        {
            input = GetComponentInChildren<InputPin>();
            Outputs = GetComponentsInChildren<OutputPin>();
            numberOfStates = 4;
            counter = 0;
        }

        // Update is called once per frame
        void Update()
        {
            this.OnCircuitUpdate();
        }
        public void OnCircuitUpdate()
        {
            if (counter == 0)
            {
                Outputs[0].Value = false;
                Outputs[1].Value = false;
            }
            else if (counter == 1)
            {
                Outputs[0].Value = true;
                Outputs[1].Value = false;
            }
            else if (counter == 1)
            {
                Outputs[0].Value = false;
                Outputs[1].Value = true;
            }
            else
            {
                Outputs[0].Value = true;
                Outputs[1].Value = true;
            }
            counter++;
        }
    }
}