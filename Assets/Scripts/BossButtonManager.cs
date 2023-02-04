using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BossButtonManager : MonoBehaviour
{
    public static BossButtonManager Instance { get; private set; }

    private List<Tile> tiles;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void AddTile(Tile tile)
    {
        tiles.Add(tile);
    }

    public void SpawnButton()
    {

    }
}
