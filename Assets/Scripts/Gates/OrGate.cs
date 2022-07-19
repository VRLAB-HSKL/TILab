using System.Linq;

namespace TILab
{
    public class OrGate : SingleOutputGate
    {
        protected override bool calculateOutput()
        {
            bool newValue = Inputs.Aggregate(false, (acc, pin) => acc || pin.Value);
            return newValue;
        }
    }
}