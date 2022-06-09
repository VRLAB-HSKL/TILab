using HTC.UnityPlugin.ColliderEvent;

namespace TILab
{
    public class LatchingButton : Button
    {
        public override void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            OutputPin.Value = !OutputPin.Value;
            
            base.OnColliderEventPressEnter(eventData);
        }
    }
}