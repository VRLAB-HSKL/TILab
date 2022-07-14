using System.Linq;
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
                var collidedGameObjects = 
                    Physics.OverlapSphere(eventData.eventCaster.transform.position, 0.1f)
                        .Except(new [] {GetComponent<Collider>()})
                        .Select(c=>c.gameObject)
                        .ToArray();

                if(collidedGameObjects.Length < 5)
                    Instantiate(spawnableItem, this.transform.position, Quaternion.identity);
                
            }
        }
    }
}