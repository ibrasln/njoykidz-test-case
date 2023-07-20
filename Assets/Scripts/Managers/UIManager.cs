using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI liveText;
    [SerializeField] private TextMeshProUGUI gameStateText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScoreText() => scoreText.text = GameManager.Instance.score.ToString();

    public void UpdateLiveText() => liveText.text = GameManager.Instance.currentLive.ToString();

    public void ActivateGameStateText(string text)
    {
        gameStateText.gameObject.SetActive(true);
        gameStateText.text = text;
    }

    public void DeactivateGameStateText() => gameStateText.gameObject.SetActive(false);
}
