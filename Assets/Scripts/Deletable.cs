using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;

namespace TILab
{
    public class Deletable : MonoBehaviour, IColliderEventDragStartHandler
    {
        public bool deletable = false;
        public void OnColliderEventDragStart(ColliderButtonEventData eventData)
        {
            if (deletable && eventData.button == Config.RemoveButton)
            {
                Destroy(gameObject);   
            }
        }
    }
}