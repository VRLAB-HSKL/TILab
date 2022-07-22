using HTC.UnityPlugin.ColliderEvent;

namespace TILab
{
    public class HoldingButton : Button
    {
        
        public override void Activate()
        {
            OutputPin.Value = true;
            base.Activate();
        }
        
        public override void Deactivate()
        {
            OutputPin.Value = false;
            base.Deactivate();
        }
    }
}