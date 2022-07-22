using System.Linq;

namespace TILab
{
    public class AndGate : SingleOutputGate
    {
        protected override bool calculateOutput()
        {
            bool newValue = Inputs.Aggregate(true, (acc, pin) => acc && pin.Value);
            return newValue;
        }
    }
}