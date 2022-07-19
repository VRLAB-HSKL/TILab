using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;

namespace TILab
{
    public class InputPin : Pin
    {
        public override void Disconnect(ConnectedCable cable)
        {
            base.Disconnect(cable);
            Value = false;
            if (_cables.Count == 0)
            {
                OnCircuitUpdate();
            }
        }
    }
}