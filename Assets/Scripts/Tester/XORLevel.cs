using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TILab.Tester
{
    public class XORLevel : Level
    {
        // Start is called before the first frame update
        void Start()
        {
            Sequence = new SequenceItem[4];
            Sequence[0] = new SequenceItem("00", "0");
            Sequence[1] = new SequenceItem("01", "1");
            Sequence[2] = new SequenceItem("10", "1");
            Sequence[3] = new SequenceItem("11", "0");


            _inputValidator = GetComponentInChildren<InputValidator>();
            _outputGenerator = GetComponentInChildren<OutputGenerator>();

            if (_inputValidator == null || _outputGenerator == null)
            {
                throw new ArgumentException(
                    "Level requires InputValidator and OutputGenerator as children in object tree");
            }
        }

    }
}
