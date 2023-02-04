using BNG;
using UnityEngine;

namespace Placuszki.VR
{
    public class Cloud : MonoBehaviour
    {
        [SerializeField] private float baseSpeed = 5;
        [SerializeField] private float maxPos = 3.5f;

        void Update()
        {
            float dir = InputBridge.Instance.LeftThumbstickAxis.x;
            // float dir = InputBridge.Instance.LeftThumbstickAxis.y;

#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.A))
                dir = 1;
            else if (Input.GetKey(KeyCode.D))
                dir = -1;
#endif

            Vector3 translateVector = new Vector3(baseSpeed * dir * Time.deltaTime, 0, 0);

            float pos = transform.position.x;
            bool shouldMove = dir > 0 && pos <= maxPos
                              || dir < 0 && pos >= -maxPos;
                              
            if (shouldMove)
            {
                transform.Translate(translateVector);
            }
        }
    }
}