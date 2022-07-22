using UnityEngine;

namespace TILab
{
    public abstract class SingleOutputGate : Gate
    {
        public override void OnCircuitUpdate()
        {
            // dirty fix to help loops settle down
            if (Random.Range(0f, 1f) < Config.IgnoreTickChangeChance)
            {
                return;
            }
            
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