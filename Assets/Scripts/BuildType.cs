using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildType : MonoBehaviour
{
    public bool Debug => debug;
    public bool Release => !debug;
    public static BuildType Instance;

    [SerializeField] private bool debug = false;
    private Queue<string> _cheatQueue;

    private const string SECRET_PASSWORD = "monke";
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            UnityEngine.Debug.LogError($"Two instances of BuildType! It should be only one on scene. Destroying {gameObject.name}.");
            Destroy(gameObject);
        }

        _cheatQueue = new Queue<string>();
    }

    private void Update()
    {
        string input = Input.inputString;
        if (input.Length == 1)
        {
            _cheatQueue.Enqueue(input);
            while (_cheatQueue.Count > SECRET_PASSWORD.Length)
                _cheatQueue.Dequeue();

            string cheatQueueString = String.Join("", _cheatQueue);
            if (cheatQueueString.Equals(SECRET_PASSWORD))
                PlayerEnteredSecretPassword();
        }
    }

    private void PlayerEnteredSecretPassword()
    {
        debug = !debug;
    }

    private void OnGUI()
    {
        if (debug)
        {
            GUI.Label(new Rect(10, 10, 100, 30), "Debug mode on");
        }
    }
}