namespace TILab
{
    public abstract class SingleOutputGate : Gate
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

        protected abstract bool calculateOutput();
    }
}