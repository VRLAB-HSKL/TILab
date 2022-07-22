using System.Linq;

namespace TILab
{
    public class XORGate : SingleOutputGate
    {
        protected override bool calculateOutput()
        {
            bool newValue = Inputs.Count(pin => pin.Value) % 2 == 1;
            return newValue;
        }
    }
}