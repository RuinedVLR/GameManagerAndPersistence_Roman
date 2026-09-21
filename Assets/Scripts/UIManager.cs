using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Canvas References")]
    [SerializeField] GameObject _mainMenuCanvas;
    [SerializeField] GameObject _levelSelectCanvas;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OpenMainMenu();
    }

    void CloseAllUI()
    {
        _mainMenuCanvas.SetActive(false);
        _levelSelectCanvas.SetActive(false);
    }

    public void OpenMainMenu()
    {
        CloseAllUI();
        _mainMenuCanvas.SetActive(true);
    }

    public void OpenLevelSelect()
    {
        CloseAllUI();
        _levelSelectCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenLevel(int levelIndex)
    {
        // Load the selected level
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelIndex);
    }
}
