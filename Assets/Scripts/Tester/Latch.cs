using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TILab.Tester
{
    public class Latch : Level
    {
        // Start is called before the first frame update
        void Start()
        {
            Sequence = new SequenceItem[16];
            Sequence[0] = new SequenceItem("00", "11");
            Sequence[1] = new SequenceItem("01", "10");
            Sequence[2] = new SequenceItem("10", "10");
            Sequence[3] = new SequenceItem("11", "01");

            if (_inputValidator == null || _outputGenerator == null)
            {
                throw new ArgumentException(
                    "Level requires InputValidator and OutputGenerator as children in object tree");
            }
        }


    }
}