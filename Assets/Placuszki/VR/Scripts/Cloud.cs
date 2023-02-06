using BNG;
using UnityEngine;

namespace Placuszki.VR
{
    public class Cloud : MonoBehaviour
    {
        [SerializeField] private float baseSpeed = 3;
        [SerializeField] private float maxPos = 2.5f;

        void Update()
        {
            float dir = -InputBridge.Instance.LeftThumbstickAxis.x;
            // float dir = InputBridge.Instance.LeftThumbstickAxis.y;

            if (Input.GetKey(KeyCode.Alpha1))
                dir = 1;
            else if (Input.GetKey(KeyCode.Alpha2))
                dir = -1;

            Vector3 translateVector = new Vector3(baseSpeed * dir * Time.deltaTime, 0, 0);

            float pos = transform.localPosition.x;
            bool shouldMove = dir > 0 && pos <= maxPos
                              || dir < 0 && pos >= -maxPos;
                              
            if (shouldMove)
            {
                transform.Translate(translateVector, Space.Self);
            }
        }
    }
}