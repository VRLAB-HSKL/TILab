using HTC.UnityPlugin.ColliderEvent;

namespace TILab
{
    public class Config
    {
        public const float CableWidth = 0.1f;
        
        public const ColliderButtonEventData.InputButton CableDragButton = ColliderButtonEventData.InputButton.Trigger;
        
        public const ColliderButtonEventData.InputButton CableRemoveButton =
            ColliderButtonEventData.InputButton.Trigger;
    }
}