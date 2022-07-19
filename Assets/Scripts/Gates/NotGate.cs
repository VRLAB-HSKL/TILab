using System;

namespace TILab
{
    public class NotGate : Gate
    {
        protected override void Awake()
        {
            base.Awake();
            if (Inputs.Length != Outputs.Length)
            {
                throw new NotSupportedException("Inputs.Length must equal Outputs.Length");
            }
        }

        public override void OnCircuitUpdate()
        {
            base.OnCircuitUpdate();
            
            for (int i = 0; i < Inputs.Length; i++)
            {
                Outputs[i].Value = !Inputs[i].Value;
            }
        }
    }
}