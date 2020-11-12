using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject endGameContainer = null;

    [SerializeField]
    private ScoreCounter scoreCounter = null;

    [SerializeField]
    private Text endGameScoreText = null;

    public static event Action OnRestartGame;

    void Start()
    {
        BombToss.OnBombSlice += EndGame;
        Countdown.OnCountdownOver += EndGame;
    }

    void OnDestroy()
    {
        BombToss.OnBombSlice -= EndGame;
        Countdown.OnCountdownOver -= EndGame;
    }

    private void EndGame()
    {
        endGameContainer.SetActive(true);
        StartCoroutine(ShowScore(scoreCounter.CurScore));
    }

    public void RestartGame()
    {
        OnRestartGame?.Invoke();
        endGameContainer.SetActive(false);
    }

    private System.Collections.IEnumerator ShowScore(int score)
    {
        var interval = new WaitForSecondsRealtime(.01f);
        int accumScore = 0;

        while (accumScore <= score)
        {            
            yield return interval;

            endGameScoreText.text = FormatNumText(accumScore);
            accumScore++;           
        }
    }

    private string FormatNumText(int num) => (num < 10 ? "0" : "") + num;
}
