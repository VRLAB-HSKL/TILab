using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TILab.Tester
{
    public class AddierLevel : Level
    {
        // Start is called before the first frame update
        void Start()
        {
            Sequence = new SequenceItem[16];
            Sequence[0] = new SequenceItem("0000", "0000");
            Sequence[1] = new SequenceItem("0001", "0001");
            Sequence[2] = new SequenceItem("0010", "0010");
            Sequence[3] = new SequenceItem("0011", "0011");
            Sequence[4] = new SequenceItem("0100", "0001");
            Sequence[5] = new SequenceItem("0101", "0010");
            Sequence[6] = new SequenceItem("0110", "0011");
            Sequence[7] = new SequenceItem("0111", "0100");
            Sequence[8] = new SequenceItem("1000", "0010");
            Sequence[9] = new SequenceItem("1001", "0011");
            Sequence[10] = new SequenceItem("1010", "0100");
            Sequence[11] = new SequenceItem("1011", "0101");
            Sequence[12] = new SequenceItem("1100", "0011");
            Sequence[13] = new SequenceItem("1101", "00100");
            Sequence[14] = new SequenceItem("1110", "00101");
            Sequence[15] = new SequenceItem("1111", "0110");


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