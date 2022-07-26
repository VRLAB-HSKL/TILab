using System;
using TMPro;
using UnityEngine;

namespace TILab
{
    public class Door : MonoBehaviour
    {
        public string sceneName;
        public string displayName = "Next Level";
        public bool active = true;

        private DoorHandle _handle;
        private TextMeshPro _text;
        
        public void Start()
        {
            _handle = GetComponentInChildren<DoorHandle>();
            _text = GetComponentInChildren<TextMeshPro>();

            if (_handle == null)
            {
                throw new NotImplementedException("Door requires handle!");
            }

            if (_text != null)
            {
                _text.text = displayName;
            }
        }

        public virtual void ChangeScene()
        {
            if (active)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
        }
    }
}