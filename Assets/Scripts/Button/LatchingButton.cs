using HTC.UnityPlugin.ColliderEvent;

namespace TILab
{
    public class LatchingButton : Button
    {
        public override void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            if (eventData.button != Config.ButtonActivationButton) return;
            if (!_buttonTopCollided) return;
            
            OutputPin.Value = !OutputPin.Value;
            base.OnColliderEventPressEnter(eventData);
        }
    }
}