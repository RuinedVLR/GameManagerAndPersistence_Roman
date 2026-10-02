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

    void Start()
    {
        LoadGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _inGame) // Load Level 1 if any Level is loaded
        {
            SceneManager.LoadScene(1);
            _currentLevelIndx = 1;
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _inGame) // Load Level 2 if any Level is loaded
        {
            SceneManager.LoadScene(2);
            _currentLevelIndx = 2;
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && _inGame) // Load Level 3 if any Level is loaded
        {
            SceneManager.LoadScene(3);
            _currentLevelIndx = 3;
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _inGame) // Quit to Main Menu if any Level is loaded
        {
            SceneManager.LoadScene(0);
            _inGame = false;
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.X) && _inGame) // Add XP if any Level is loaded
        {
            _xp += 10;
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.H) && _inGame) // Decrease Health if any Level is loaded

        {
            _health -= 10;
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.S) && _inGame) // Increase Score if any Level is loaded
        {
            _score += 10;
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
