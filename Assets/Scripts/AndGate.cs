using System.Linq;

namespace TILab
{
    public class AndGate : Gate
    {
        public override void OnCircuitUpdate()
        {
            base.OnCircuitUpdate();
            bool newValue = Inputs.Aggregate(true, (acc, pin) => acc && pin.Value);
            foreach (var outputPin in Outputs)
            {
                outputPin.Value = newValue;
            }
        }
    }
}