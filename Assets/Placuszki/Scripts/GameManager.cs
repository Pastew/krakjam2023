using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        ReadyToPlay,
        playing,
        End
    }

    public GameState _gamestate = GameState.ReadyToPlay;

    public AudioSource audio;

    public GameObject canvasStart;
    public GameObject canvasEnd;
    public Text Label;

    public int buttonCount = 5;

    private int pressedButtonCounter = 0;

    private int monkeCounter = 0;

    private float _timeSinceEndGame;

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
        canvasStart.SetActive(true);
        canvasEnd.SetActive(false);
    }

    public void MonkeButton()
    {
        pressedButtonCounter++;
        Debug.Log($"Monke button pressed, counter = {pressedButtonCounter}");
        SpawnNextButton();
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
        canvasEnd.gameObject.SetActive(true);
        _timeSinceEndGame = 0;
    }

    private void Update()
    {
        if (Input.anyKey && _gamestate == GameState.End && _timeSinceEndGame > 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if(_gamestate == GameState.End)
        {
            _timeSinceEndGame += Time.deltaTime;
        }

        if (Input.anyKey && _gamestate == GameState.ReadyToPlay)
        {
            _gamestate = GameState.playing;
            canvasStart.gameObject.SetActive(false);
            SpawnNextButton();
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
