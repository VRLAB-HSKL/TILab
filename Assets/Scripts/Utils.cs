using System.Linq;
using UnityEngine;

namespace TILab
{
    public class Utils
    {
        public static bool[] StringToBinaryArray(string val)
        {
            bool[] bools = val.ToCharArray().Select(character => character.Equals('1') ? true : false).ToArray();
            Debug.Log(string.Join("", bools.Select(b => b ? "1" : "0")));
            return bools;
        }
    }
}