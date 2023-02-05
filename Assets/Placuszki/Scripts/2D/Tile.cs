using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject _button;
    public Transform _spawn;

    void Start()
    {
        BossButtonManager.Instance.AddTile(this);
    }

    public void CreateButton()
    {
        if (_button != null)
            Instantiate(_button, _spawn.position, Quaternion.identity);
    }
    
}
