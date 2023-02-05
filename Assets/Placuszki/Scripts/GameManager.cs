using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        ReadyToPlay,
        End
    }

    public GameState _gamestate = GameState.ReadyToPlay;

    public AudioSource audio;

    public GameObject _UI;
    public GameObject _endUI;
    public Text Label;

    public int buttonCount = 5;

    private int pressedButtonCounter = 0;

    private int monkeCounter = 0;


    public Vector3 buttonTimeRandomizer = new Vector2(4, 10);

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
        pressedButtonCounter++;
        audio.Play();
    }

    public void MonkeHIT()
    {
        monkeCounter++;

        if (monkeCounter == 4)
        {
            _gamestate = GameState.End;
            Label.text = "BOSS WINS!";
            EndGame();
        }

    }

    void EndGame()
    {
        _UI.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.anyKey && _gamestate == GameState.End)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.anyKey && _gamestate == GameState.ReadyToPlay)
        {
            _UI.gameObject.SetActive(false);
        }
    }

    private void SpawnNextButton()
    {
        if (pressedButtonCounter <= buttonCount)
        {
            float random = Random.Range(buttonTimeRandomizer.x, buttonTimeRandomizer.y);
            StartCoroutine("ButtonRoutine", random);
        }
        else
        {
            _gamestate = GameState.End;
            Label.text = "MONKES WINS!";
            EndGame();
        }
    }

    IEnumerator ButtonRoutine(float randomtime)
    {
        yield return new WaitForSeconds(randomtime);

        BossButtonManager.Instance.SpawnButton();
    }
}
