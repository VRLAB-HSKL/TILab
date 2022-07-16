using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TILab.Tester
{
    public class Latcth : Level
    {
        // Start is called before the first frame update
        void Start()
        {
            Sequence = new SequenceItem[16];
            Sequence[0] = new SequenceItem("00", "0");
            Sequence[1] = new SequenceItem("01", "0");
            Sequence[2] = new SequenceItem("10", "0");
            Sequence[3] = new SequenceItem("11", "0");
            Sequence[4] = new SequenceItem("00", "0");
            Sequence[5] = new SequenceItem("01", "0");
            Sequence[6] = new SequenceItem("10", "1");
            Sequence[7] = new SequenceItem("11", "0");

            if (_inputValidator == null || _outputGenerator == null)
            {
                throw new ArgumentException(
                    "Level requires InputValidator and OutputGenerator as children in object tree");
            }
        }


    }
}