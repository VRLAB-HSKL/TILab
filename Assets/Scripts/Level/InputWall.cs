using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TILab
{
    public class InputWall : MonoBehaviour, CircuitItem
    {
        List<bool> expectedResults { get; set; }
        bool[] results { get; set; }
        public InputPin inputPin { get; set; }
        int counter { get; set; }
        Light resultLight { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            counter = 0;
            expectedResults = new List<bool> { false, false, false, true };
            results = new bool[] { false, false, false, false };
            inputPin = GetComponentInChildren<InputPin>();
            resultLight = GetComponentInChildren<Light>();
        }
        void Update()
        {
            this.OnCircuitUpdate();
        }

        public void  OnCircuitUpdate()
        {
            if (counter == 0)
            {
                results[counter] = (inputPin.Value == expectedResults[counter]);
                counter++;
            }
            else if (counter == 1)
            {
                results[counter] = (inputPin.Value == expectedResults[counter]);
                counter++;
            }
            else if (counter == 1)
            {
                results[counter] = (inputPin.Value == expectedResults[counter]);
                counter++;
            }
            else
            {
                results[counter] = (inputPin.Value == expectedResults[counter]);
                counter = 0;
            }

            if (results[0] && results[1] && results[2] && results[3])
            {
                Color c = new Color();
                c.r = 0f;
                c.g = 1f;
                //c.b= lightFactor / 100f;
                c.a = 0f;
                resultLight.color = c;
            }
        }
    }
}