using System;
using UnityEngine;

namespace TILab.Tester
{
    public class Level : MonoBehaviour
    {
        public SequenceItem[] Sequence =
        {
            new SequenceItem("00", "0"),
            new SequenceItem("01", "0"),
            new SequenceItem("10", "0"),
            new SequenceItem("11", "1"),
        };

        private int _sequencePos = 0;
        private int _sequenceTicks = 0;
        private bool _runSequence = false;
        private bool _sequenceResults = true;
        
        protected InputValidator _inputValidator;
        protected OutputGenerator _outputGenerator;
        
        public virtual void Start()
        {
            _inputValidator = GetComponentInChildren<InputValidator>();
            _outputGenerator = GetComponentInChildren<OutputGenerator>();
            
            if (_inputValidator == null || _outputGenerator == null)
            {
                throw new ArgumentException(
                    "Level requires InputValidator and OutputGenerator as children in object tree");
            }
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
                        _inputValidator.SetStatus(_sequenceResults);
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
                    _sequenceResults = _sequenceResults & _inputValidator.Test(Sequence[_sequencePos].Input);
                    Debug.Log($"new val: {_sequenceResults}");
                }

                _sequenceTicks++;
            }
        }
    }
}