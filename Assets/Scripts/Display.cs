using System;
using TMPro;
using UnityEngine;

namespace TILab
{
    public class Display : MonoBehaviour
    {
        private TextMeshPro _tmp;
        [field: SerializeField]
        public InputPin[] Inputs { get; set; }

        private void Start()
        {
            _tmp = GetComponentInChildren<TextMeshPro>();
        }

        private void Update()
        {
            int sum = 0;
            for (int i = 0; i < Inputs.Length; i++)
            {
                if (Inputs[i].Value)
                {
                    sum += (1 << i);
                }
            }
            
            _tmp.SetText(sum.ToString());
        }
    }
}