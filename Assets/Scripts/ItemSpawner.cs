using System.Linq;
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;

namespace TILab
{
    public class ItemSpawner : MonoBehaviour, IColliderEventDragStartHandler
    {
        public GameObject spawnableItem;
        public Vector3 positionalOffset;
        
        public void OnColliderEventDragStart(ColliderButtonEventData eventData)
        {
            Debug.Log(eventData);
            if (eventData.button == ColliderButtonEventData.InputButton.Trigger)
            {
                var collidedGameObjects = 
                    Physics.OverlapSphere(this.transform.position+ new Vector3(0,1,0), 0.1f)
                        .Except(new [] {GetComponent<Collider>()})
                        .Select(c=>c.gameObject)
                        .ToArray();

                if(collidedGameObjects.Length < 1)
                    Instantiate(spawnableItem, positionalOffset, Quaternion.identity);
                
            }
        }
    }
}