using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{   
    void Start()
    {
        BossButtonManager.Instance.AddTile(this);
    }

    
}
