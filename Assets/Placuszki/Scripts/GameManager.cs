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

    public int buttonCount = 5;

    public  Vector3 buttonTimeRandomizer;

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

    public void MonkeButton()
    {

    }

    void StartGame()
    {

    }

    private void SpawnNextButton()
    {

    }

    IEnumerator ButtonRoutine(float randomtime)
    {
        yield return new WaitForSeconds(randomtime);


    }
}
