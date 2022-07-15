using System;
using System.Linq;
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;

namespace TILab
{
    public class ItemSpawner : MonoBehaviour, IColliderEventDragStartHandler
    {
        public GameObject landingPad;
        public GameObject spawnableItem;
        public Vector3 positionalOffset;

        public void Awake()
        {
            SpawnItem();
        }

        public void OnColliderEventDragStart(ColliderButtonEventData eventData)
        {
            Debug.Log(eventData);
            if (eventData.button == ColliderButtonEventData.InputButton.Trigger)
            {
                SpawnItem();
            }
        }

        private void SpawnItem()
        {
            var collidedGameObjects = 
                Physics.OverlapSphere(this.landingPad.transform.position+ positionalOffset, 0.1f)
                    .Except(new [] {GetComponent<Collider>()})
                    .Select(c=>c.gameObject)
                    .ToArray();

            if (collidedGameObjects.Length < 1)
            {
                Instantiate(spawnableItem, landingPad.transform.position+ positionalOffset, Quaternion.identity);
            }

        }
    }
}