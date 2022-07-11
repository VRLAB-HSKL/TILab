using System;
using System.Linq;
using UnityEngine;

namespace TILab.Tester
{
    public class TesterInput : MonoBehaviour
    {
        [SerializeField]
        public GameObject StatusLight;
        
        private Renderer _renderer;
        private bool _value = false;
        private InputPin[] _inputs;

        public void Start()
        {
            _renderer = StatusLight.GetComponent<Renderer>();
            _inputs = GetComponentsInChildren<InputPin>();
        }

        public bool Test(string expected)
        {
            bool[] values = Utils.StringToBinaryArray(expected);
            if (values.Length != _inputs.Length) return false;

            bool[] inputValues = _inputs.Select(pin => pin.Value).ToArray();
            Debug.Log($"inputValues: {string.Join("", inputValues.Select(val => val ? "1" : "0"))}");
            Debug.Log($"testValues: {string.Join("", values.Select(val => val ? "1" : "0"))}");
            bool testValue = values.Zip(inputValues, (testValue, inputValue) => testValue == inputValue)
                .Aggregate(true, (a, b) => a && b);

            Debug.Log($"test result: {testValue}");
            return testValue;
        }

        public void SetStatus(bool val)
        {
            _value = val;

            var color = _value ? Color.green : Color.red;
            _renderer.material.color = color;
        }
    }
}