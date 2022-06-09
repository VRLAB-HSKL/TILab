using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;

namespace TILab
{
    public class InputPin : Pin, IColliderEventPressExitHandler
    {
        public void OnColliderEventPressExit(ColliderButtonEventData eventData)
        {
            Value = !Value;
            OnCircuitUpdate();
        }
    }
}