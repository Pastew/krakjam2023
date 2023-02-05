using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        ReadyToPlay,
        Playing,
        BossWins,
        MonkeMonkeMonke
    }

    public GameState _gamestate = GameState.ReadyToPlay;

    public GameObject _StartUI;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _gamestate = GameState.ReadyToPlay;
    }
}
