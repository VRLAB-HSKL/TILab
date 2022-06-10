using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace TILab
{
    public class Pin : MonoBehaviour, CircuitItem
    {
        [field: SerializeField] 
        public bool Value { get; set; }
        
        public Gate Gate { get; private set; }
        
        private Renderer _renderer;

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
    }
}