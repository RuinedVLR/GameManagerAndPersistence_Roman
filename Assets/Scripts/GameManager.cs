using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int _currentLevel;
    public int _health;
    public int _score;
    public int _xp;
    
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SceneManager.LoadScene(3);
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
            SceneManager.LoadScene(0);
    }

    public void SaveGame()
    {
        PlayerData data = new PlayerData
        {
            currentLevel = _currentLevel,
            health = _health,
            score = _score,
            xp = _xp
        };

        SaveSystem.Save(data);
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.Load();

        _currentLevel = data.currentLevel;
        _health = data.health;
        _score = data.score;
        _xp = data.xp;
    }
}
