using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _healthText;
    [SerializeField] private TMPro.TextMeshProUGUI _scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI _xpText;
    [SerializeField] private TMPro.TextMeshProUGUI _levelText;

    private void Start()
    {
        _levelText.text = $"Level: {GameManager.Instance._currentLevelIndx}";
    }

    void Update()
    {
        _xpText.text = $"XP: {GameManager.Instance._xp}";
        _scoreText.text = $"Score: {GameManager.Instance._score}";
        _healthText.text = $"Health: {GameManager.Instance._health}";

    }
} 
