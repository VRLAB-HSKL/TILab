using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;

namespace TILab
{
    public class Clonable : MonoBehaviour, IColliderEventDragStartHandler
    {
        public GameObject spawnableItem;
        
        public void OnColliderEventDragStart(ColliderButtonEventData eventData)
        {
            Debug.Log(eventData);
            if (eventData.button == ColliderButtonEventData.InputButton.GripOrHandTrigger)
            {
                Instantiate(spawnableItem, this.transform.position, Quaternion.identity);
            }
        }
    }
}