using UnityEngine;

namespace Placuszki.VR
{
    public class AppType : MonoBehaviour
    {
        public static AppType Instance;
        public static bool IsVr => Application.platform == RuntimePlatform.Android;
        
        void Start()
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