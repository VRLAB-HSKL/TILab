using System;
using System.Collections.Generic;
using UnityEngine;

namespace TILab.Tester
{
    public class Level : MonoBehaviour
    {
        public SequenceItem[] Sequence =
        {
            new SequenceItem("1101", "1111"),
            new SequenceItem("1001", "0100"),
            new SequenceItem("0001", "0100"),
            new SequenceItem("1111", "1111"),
            new SequenceItem("0011", "0100")
        };

        private int _sequencePos = 0;
        private int _sequenceTicks = 0;
        private bool _runSequence = false;
        private bool _sequenceResults = true;
        
        private TesterInput _input;
        private OutputGenerator _outputGenerator;
        
        private void Start()
        {
            _input = GetComponentInChildren<TesterInput>();
            _outputGenerator = GetComponentInChildren<OutputGenerator>();
        }

        public void RunSequence()
        {
            if (!_runSequence)
            {
                _runSequence = true;
                _sequenceTicks = 0;
                _sequencePos = 0;
                _sequenceResults = true;
            }
        }

        public void FixedUpdate()
        {
            if (_runSequence)
            {
                if (_sequenceTicks > Sequence[_sequencePos].WaitTicks)
                {
                    _sequenceTicks = 0;
                    _sequencePos += 1;

                    if (Sequence.Length <= _sequencePos)
                    {
                        _runSequence = false;
                        _outputGenerator.ResetOutputs();
                        _input.SetStatus(_sequenceResults);
                        return;
                    }
                }
                if (_sequenceTicks == 0)
                {
                    _outputGenerator.SetOutputs(Sequence[_sequencePos].Output);
                }

                if (_sequenceTicks == Sequence[_sequencePos].WaitTicks)
                {
                    Debug.Log($"current val: {_sequenceResults}");
                    _sequenceResults = _sequenceResults & _input.Test(Sequence[_sequencePos].Input);
                    Debug.Log($"new val: {_sequenceResults}");
                }

                _sequenceTicks++;
            }
        }
    }
}