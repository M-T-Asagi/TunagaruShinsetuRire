using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public class GameFinishEventArgs : System.EventArgs
    {

    }

    [SerializeField]
    int totalSeconds = 90;

    [SerializeField]
    TextMeshProUGUI reamingTimeText;

    public System.EventHandler<GameFinishEventArgs> gameFinish;

    float startTime = 0;
    bool gaming = false;

    public void StartGame()
    {
        Debug.Log("Game started!");

        gaming = true;
        startTime = Time.time;

        string newTime = (totalSeconds / 60) + ":" + (totalSeconds % 60);
        reamingTimeText.text = newTime;

        gameFinish += (object sender, GameFinishEventArgs args) =>
        {
            Debug.Log("Game is end");
        };
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

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0, 500, 100, 100), "Game Start"))
        {
            StartGame();
        }
    }
}
