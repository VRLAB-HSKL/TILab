using System.Linq;

namespace TILab
{
    public class OrGate : Gate
    {
        public override void OnCircuitUpdate()
        {
            base.OnCircuitUpdate();
            bool newValue = calculateOutput();
            foreach (var outputPin in Outputs)
            {
                outputPin.Value = newValue;
            }
        }
        virtual protected bool calculateOutput()
        {
            return Inputs.Aggregate(false, (acc, pin) => acc || pin.Value);
        }
    }
}