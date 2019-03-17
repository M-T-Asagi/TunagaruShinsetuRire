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

    [SerializeField]
    Animator finishCountDownAnimator = null;

    [SerializeField]
    GameStateManager stateManager;

    public System.EventHandler<GameStartEventArgs> gameStart;
    public System.EventHandler<GameFinishEventArgs> gameFinish;

    float startTime = 0;
    bool gaming = false;
    public bool Gaming { get { return gaming; } }

    bool finishing = false;

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Game started!");
        stateManager.StateNow = GameStateManager.State.CountDown;
        SetTimeText(totalSeconds);
        startCountDownAnimator.SetBool("GameStart", true);
        StartCoroutine(_StartGame());
    }

    IEnumerator _StartGame()
    {
        yield return new WaitForSeconds(3f);

        stateManager.StateNow = GameStateManager.State.GamePlaying;
        gaming = true;
        startTime = Time.time;

        SetTimeText(totalSeconds);

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
            SetTimeText(reamingTime);

            if(reamingTime <= 10 && !finishing)
            {
                finishing = true;
                finishCountDownAnimator.SetBool("Finishing", true);
            }

            if (reamingTime <= 0)
            {
                FinishGaming();
            }
        }
    }

    void SetTimeText(int reamingTime)
    {
        int sec = reamingTime % 60;
        string newTime = (reamingTime > 0) ? (reamingTime / 60) + ":" + (sec < 10 ? "0" : "") + sec : "0:00";
        reamingTimeText.text = newTime;
    }

    public void FinishGaming()
    {
        stateManager.StateNow = GameStateManager.State.GameEnd;
        gaming = false;
        gameFinish?.Invoke(this, new GameFinishEventArgs());
    }
}
