using UnityEngine;
using Random = UnityEngine.Random;

public class TossGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints = null;

    [SerializeField]
    private GameObject[] tosses = null;

    [SerializeField]
    private Transform tossContainer = null;

    [SerializeField]
    private float delayBetweenToss = 2f;

    private bool shouldToss;

    void Start()
    {       
        BombToss.OnBombSlice += StopTossing;
        Countdown.OnCountdownOver += StopTossing;
        GameOverHandler.OnRestartGame += StartCoroutineTossing;
        StartCoroutineTossing();
    }

    private void StartCoroutineTossing()
    {
        shouldToss = true;
        StartCoroutine(StartTossing());
    } 

    private void OnDestroy() 
    {
        BombToss.OnBombSlice -= StopTossing;
        Countdown.OnCountdownOver -= StopTossing;
        GameOverHandler.OnRestartGame -= StartCoroutineTossing;
    }

    private void StopTossing() => shouldToss = false;

    private System.Collections.IEnumerator StartTossing()
    {
        var delay = new WaitForSecondsRealtime(delayBetweenToss);

        while (shouldToss)
        {
            yield return delay;

            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            var toss = tosses[Random.Range(0, tosses.Length)];
            Instantiate(toss, spawnPoint.position, Quaternion.identity, tossContainer);
        }

        DestroyAllTosses();
    }

    private void DestroyAllTosses()
    {       
        foreach (Transform toss in tossContainer.transform) Destroy(toss.gameObject);
    }
}
