using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Countdown : MonoBehaviour
{
    [SerializeField]
    private int startMin = 1, startSec = 0;

    private Text countdown;
    
    private int curMin, curSec;

    public static event System.Action OnCountdownOver;

    void Start()
    {
        GameOverHandler.OnRestartGame += StartCountdown;
        countdown = GetComponent<Text>();
        StartCountdown();
    }

    private void OnDestroy() 
    {
        GameOverHandler.OnRestartGame -= StartCountdown;
    }

    private System.Collections.IEnumerator Tick()
    {
        var interval = new WaitForSecondsRealtime(1f);
        
        while (curMin > 0 || curSec > 0)
        {
            yield return interval;

            if (curSec == 0)
            {
                curMin--;
                curSec = 59;
            }
            else curSec--;

            ShowRemainingTime();
        }

        ShowRemainingTime();
        OnCountdownOver?.Invoke();
    }   

    public void StartCountdown()
    {
        (curMin, curSec) = (startMin, startSec);
        ShowRemainingTime();
        StartCoroutine(Tick());
    }

    private void ShowRemainingTime() => countdown.text = FormatNumText(curMin) + ":" + FormatNumText(curSec);

    private string FormatNumText(int num) => (num < 10 ? "0" : "") + num;
}
