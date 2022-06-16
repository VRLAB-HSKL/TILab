using System.Linq;
using System.Numerics;
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;

namespace TILab
{
    public class Pin : MonoBehaviour, CircuitItem, IColliderEventDragStartHandler,
        IColliderEventDragUpdateHandler, IColliderEventDragEndHandler
    {
        [field: SerializeField] 
        public bool Value { get; set; }
        
        public Gate Gate { get; private set; }
        
        private Renderer _renderer;

        private bool _isCreatingCable = false;
        private BaseCable _cable;
        private GameObject _cableObject;

        private void Start()
        {
            Gate = GetComponentInParent<Gate>();
            this._renderer = this.GetComponent<Renderer>();
            
            this.OnCircuitUpdate();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + transform.up);
        }

        public virtual void OnCircuitUpdate()
        {
            var color = this.Value ? Color.green : Color.red;
            _renderer.material.color = color;
        }

        public void OnColliderEventDragStart(ColliderButtonEventData eventData)
        {
            Debug.Log("OnColliderEventDragStart");
            if (eventData.button != ColliderButtonEventData.InputButton.Trigger) return;
            
            _cableObject = new GameObject();
            LineRenderer lineRenderer = _cableObject.AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.1f;
            _cable = _cableObject.AddComponent<BaseCable>();
            _cable.BeginPos = transform.position;
            _cable.EndPos = _cable.BeginPos;

            _isCreatingCable = true;
        }

        public void OnColliderEventDragUpdate(ColliderButtonEventData eventData)
        {
            Debug.Log("OnColliderEventDragUpdate");
            if (!_isCreatingCable) return;
            _cable.EndPos = eventData.eventCaster.transform.position;
            // Debug.Log(eventData.);
        }

        public void OnColliderEventDragEnd(ColliderButtonEventData eventData)
        {
            Debug.Log("OnColliderEventDragEnd");
            if (!_isCreatingCable) return;
            _isCreatingCable = false;
            
            var collidedGameObjects = 
                Physics.OverlapSphere(eventData.eventCaster.transform.position, 0.1f /*Radius*/)
                    .Except(new [] {GetComponent<Collider>()})
                    .Select(c=>c.gameObject)
                    .ToArray();
            
            foreach (var collidedGameObject in collidedGameObjects)
            {
                var pin = collidedGameObject.GetComponent<Pin>();
                if (pin != null)
                {
                    Destroy(_cableObject);
                    _cable = null;
                    _cableObject = null;
                    if (GetType() == typeof(InputPin) && pin.GetType() == typeof(OutputPin) ||
                        GetType() == typeof(OutputPin) && pin.GetType() == typeof(InputPin))
                    {
                        var test = new GameObject();
                        LineRenderer lineRenderer = test.AddComponent<LineRenderer>();
                        lineRenderer.startWidth = 0.1f;
                        var connectedCable = test.AddComponent<ConnectedCable>();
                        if (GetType() == typeof(InputPin))
                        {
                            connectedCable.InputPin = (InputPin) this;
                            connectedCable.OutputPin = (OutputPin) pin;
                        }
                        else
                        {
                            connectedCable.InputPin = (InputPin) pin;
                            connectedCable.OutputPin = (OutputPin) this;
                        }
                    }
                    
                }
            }
        }
    }
}