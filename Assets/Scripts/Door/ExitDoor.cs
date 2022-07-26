using UnityEngine;

namespace TILab
{
    public class ExitDoor : Door
    {
        public override void ChangeScene()
        {
            if (active)
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }
    }
}