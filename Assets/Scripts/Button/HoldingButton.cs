using HTC.UnityPlugin.ColliderEvent;

namespace TILab
{
    public class HoldingButton : Button
    {
        
        public override void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            OutputPin.Value = true;
            
            base.OnColliderEventPressEnter(eventData);
        }
        
        public override void OnColliderEventPressExit(ColliderButtonEventData eventData)
        {
            OutputPin.Value = false;
            
            base.OnColliderEventPressExit(eventData);
        }
    }
}