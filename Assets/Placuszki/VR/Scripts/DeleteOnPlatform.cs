using System.Collections.Generic;
using UnityEngine;

namespace Placuszki.VR
{
    public class DeleteOnPlatform : MonoBehaviour
    {
        [SerializeField] private List<GameObject> deleteOnPC;
        [SerializeField] private List<GameObject> deleteOnVR;

        private void Start()
        {
            if(AppType.Instance.PC)
                deleteOnPC.ForEach(Destroy);
            
            if(AppType.Instance.VR)
                deleteOnVR.ForEach(Destroy);
        }
    }
}
