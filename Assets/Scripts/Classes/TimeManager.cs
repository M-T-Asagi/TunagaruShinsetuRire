using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public class GameStartEventArgs : System.EventArgs
    {

    }

    public class GameFinishEventArgs : System.EventArgs
    {

    }

    [SerializeField]
    int totalSeconds = 90;

    [SerializeField]
    TextMeshProUGUI reamingTimeText = null;

    [SerializeField]
    Animator startCountDownAnimator = null;

    public System.EventHandler<GameStartEventArgs> gameStart;
    public System.EventHandler<GameFinishEventArgs> gameFinish;

    float startTime = 0;
    bool gaming = false;
    public bool Gaming { get { return gaming; } }

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Game started!");
        startCountDownAnimator.SetBool("GameStart", true);
        StartCoroutine(_StartGame());
    }

    IEnumerator _StartGame()
    {
        yield return new WaitForSeconds(3f);

        gaming = true;
        startTime = Time.time;

        string newTime = (totalSeconds / 60) + ":" + (totalSeconds % 60);
        reamingTimeText.text = newTime;

        gameStart?.Invoke(this, new GameStartEventArgs());

        yield return new WaitForSeconds(2f);
        startCountDownAnimator.SetBool("GameStart", false);
    }

    // Update is called once per frame
    void Update()
    {
        float timeNow = Time.time;
        if(gaming)
        {
            int elapsedTime = (int)(timeNow - startTime);

            int reamingTime = totalSeconds - elapsedTime;
            string newTime = (reamingTime > 0) ? (reamingTime / 60) + ":" + (reamingTime % 60) : "0:00";
            reamingTimeText.text = newTime;

            if (reamingTime <= 0)
            {
                FinishGaming();
            }
        }
    }

    public void FinishGaming()
    {
        gaming = false;
        gameFinish?.Invoke(this, new GameFinishEventArgs());
    }
}
