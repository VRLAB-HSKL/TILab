using System;
using UnityEngine;

namespace TILab
{
    public class ButtonTop : MonoBehaviour
    {
        private Action _enterCallback;
        private Action _exitCallback;

        public void RegisterEnterCallback(Action action)
        {
            _enterCallback = action;
        }
        
        public void RegisterExitCallback(Action action)
        {
            _exitCallback = action;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _enterCallback?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            _exitCallback?.Invoke();
        }
    }
}