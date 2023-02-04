using System.Collections;
using System.Collections.Generic;
using Placuszki.VR;
using UnityEngine;

public class VrPlayer : MonoBehaviour
{
    void Start()
    {
        if (AppType.Instance.VR)
            gameObject.SetActive(true);
    }
}