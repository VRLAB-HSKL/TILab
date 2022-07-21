using System;
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;

namespace TILab
{
    public class ButtonCollider : MonoBehaviour, IColliderEventPressEnterHandler, IColliderEventPressExitHandler
    {
        private Button _button;
        
        public void Start()
        {
            _button = GetComponentInParent<Button>();

            if (_button == null)
            {
                throw new NotImplementedException("ButtonCollider required Button as parent!");
            }
        }

        public virtual void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            if (eventData.button != Config.ButtonActivationButton) return;
            Debug.Log("ButtonCollider enter");
            
            _button.Activate();
        }

        public virtual void OnColliderEventPressExit(ColliderButtonEventData eventData)
        {
            if (eventData.button != Config.ButtonActivationButton) return;
            Debug.Log("ButtonCollider exit");
            
            _button.Deactivate();
        }
    }
}