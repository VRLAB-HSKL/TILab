using UnityEngine;

namespace TILab
{
    public class Cable : MonoBehaviour, CircuitItem
    {
        public Pin[] Connections { get; set; }
        
        public void OnCircuitUpdate()
        {
        }
    }
}