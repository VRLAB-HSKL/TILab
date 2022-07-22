using HTC.UnityPlugin.ColliderEvent;

namespace TILab
{
    public class LatchingButton : Button
    {
        public override void Activate()
        {
            OutputPin.Value = !OutputPin.Value;
            base.Activate();
        }
    }
}