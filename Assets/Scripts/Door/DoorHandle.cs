using System;
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Vive;
using UnityEngine;

namespace TILab
{
    public class DoorHandle : MonoBehaviour, IColliderEventPressEnterHandler
    {
        private Door _door;
        
        public void Start()
        {
            _door = GetComponentInParent<Door>();

            if (_door == null)
            {
                throw new NotImplementedException("DoorHandle requires door as parent!");
            }
        }

        public virtual void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            if (eventData.button == Config.DoorActivationButton)
            {
                _door.ChangeScene();
            }
        }
    }
}