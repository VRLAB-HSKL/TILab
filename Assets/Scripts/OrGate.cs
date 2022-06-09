using System.Linq;

namespace TILab
{
    public class OrGate : Gate
    {
        public override void OnCircuitUpdate()
        {
            base.OnCircuitUpdate();
            bool newValue = Inputs.Aggregate(false, (acc, pin) => acc || pin.Value);
            foreach (var outputPin in Outputs)
            {
                outputPin.Value = newValue;
            }
        }
    }
}