using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;

namespace TILab
{
    public class Deletable : MonoBehaviour, IColliderEventDragStartHandler
    {
        public bool deletable = true;
        public GameObject toDelete;
        public void OnColliderEventDragStart(ColliderButtonEventData eventData)
        {
            Debug.Log(eventData);
            if (deletable && eventData.button == Config.RemoveButton)
            {
                if (toDelete != null)
                {
                    Destroy(toDelete);
                }
                else
                {
                    Destroy(gameObject);   
                }
            }
        }
    }
}