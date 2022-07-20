using HTC.UnityPlugin.ColliderEvent;

namespace TILab
{
    public class HoldingButton : Button
    {
        
        public override void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            if (eventData.button != Config.ButtonActivationButton) return;
            if (!_buttonTopCollided) return;
            
            OutputPin.Value = true;
            base.OnColliderEventPressEnter(eventData);
        }
        
        public override void OnColliderEventPressExit(ColliderButtonEventData eventData)
        {
            if (eventData.button != Config.ButtonActivationButton) return;
            if (!_buttonTopCollided) return;
            
            OutputPin.Value = false;
            base.OnColliderEventPressExit(eventData);
        }
    }
}