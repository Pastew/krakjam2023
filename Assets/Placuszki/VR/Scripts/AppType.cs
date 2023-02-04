using UnityEngine;

namespace Placuszki.VR
{
    public class AppType : MonoBehaviour
    {
        public static AppType Instance;
        public bool VR => Application.platform == RuntimePlatform.Android;
        public bool PC => !VR;
        
        void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Trying to create a second singleton. Deleting it.");
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
    }
}