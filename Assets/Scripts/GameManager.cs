using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int _currentLevelIndx;
    public int _health;
    public int _score;
    public int _xp;

    public bool _inGame = false;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _inGame)
        {
            SceneManager.LoadScene(1);
            _currentLevelIndx = 1;
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _inGame)
        {
            SceneManager.LoadScene(2);
            _currentLevelIndx = 2;
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && _inGame)
        {
            SceneManager.LoadScene(3);
            _currentLevelIndx = 3;
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
            _inGame = false;
            SaveGame();
        }
    }

    public void SaveGame()
    {
        PlayerData data = new PlayerData
        {
            currentLevel = _currentLevelIndx,
            health = _health,
            score = _score,
            xp = _xp
        };

        SaveSystem.Save(data);
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.Load();

        _currentLevelIndx = data.currentLevel;
        _health = data.health;
        _score = data.score;
        _xp = data.xp;
    }
}
