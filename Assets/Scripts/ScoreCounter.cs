using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private Text scoreText = null;

    private int curScore = 0;

    public int CurScore
    {
        get => curScore;
        set
        {
            curScore = value;
            scoreText.text = FormatNumText(value);
        }
    }

    private void Start() 
    {
        FruitToss.OnFruitSlice += UpdateScore;
        GameOverHandler.OnRestartGame += Reset;
    }

    private void OnDestroy() 
    {
        FruitToss.OnFruitSlice -= UpdateScore;
        GameOverHandler.OnRestartGame -= Reset;
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.A)) CurScore += 100;
        #endif
    }

    public void Reset() => CurScore = 0;

    private void UpdateScore(int obtainedScore) => CurScore += obtainedScore;

    private string FormatNumText(int num) => (num < 10 ? "0" : "") + num;
}
