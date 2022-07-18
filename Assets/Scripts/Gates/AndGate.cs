using System.Linq;

namespace TILab
{
    public class AndGate : Gate
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
            return Inputs.Aggregate(true, (acc, pin) => acc && pin.Value);
        }
    }
}