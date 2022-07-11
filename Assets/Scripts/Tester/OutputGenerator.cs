using System;
using UnityEngine;

namespace TILab.Tester
{
    public class OutputGenerator : MonoBehaviour
    {
        private Level _level;
        private OutputPin[] _outputs;
        private InputPin _activationPin;

        private bool _lastTickActivated = false;
        private void Start()
        {
            _level = GetComponentInParent<Level>();
            _outputs = GetComponentsInChildren<OutputPin>();
            _activationPin = GetComponentInChildren<InputPin>();
        }

        public void SetOutputs(String val)
        {
            bool[] desiredOutputs = Utils.StringToBinaryArray(val);
            if (desiredOutputs.Length != _outputs.Length)
            {
                Debug.LogError($"desiredOutputs.Length({desiredOutputs.Length}) != _outputs.Length({_outputs.Length})");
            }

            for (int i = 0; i < _outputs.Length; i++)
            {
                bool value = desiredOutputs.Length > i && desiredOutputs[i];
                _outputs[i].Value = value;
                _outputs[i].OnCircuitUpdate();
            }
        }

        public void ResetOutputs()
        {
            foreach (var output in _outputs)
            {
                output.Value = false;
                output.OnCircuitUpdate();
            }
        }

        public void FixedUpdate()
        {
            if (_activationPin.Value && !_lastTickActivated)
            {
                Debug.Log("triggering Sequence");
                _lastTickActivated = true;
                _level.RunSequence();
            }
            else
            {
                _lastTickActivated = _activationPin.Value;
            }
        }
    }
}