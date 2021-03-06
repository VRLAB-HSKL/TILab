using HTC.UnityPlugin.ColliderEvent;

namespace TILab
{
    public class Config
    {
        public const float IgnoreTickChangeChance = 0.01f;
        
        public const ColliderButtonEventData.InputButton CableDragButton = ColliderButtonEventData.InputButton.Trigger;
        public const ColliderButtonEventData.InputButton ButtonActivationButton = ColliderButtonEventData.InputButton.Trigger;
        public const ColliderButtonEventData.InputButton DoorActivationButton = ColliderButtonEventData.InputButton.Trigger;

        public const ColliderButtonEventData.InputButton RemoveButton =
            ColliderButtonEventData.InputButton.FunctionKey;
    }
}