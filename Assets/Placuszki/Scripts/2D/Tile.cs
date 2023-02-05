using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject _button;

    void Start()
    {
        BossButtonManager.Instance.AddTile(this);
    }

    public void CreateButton()
    {
        _button.SetActive(true);
    }
    
}
