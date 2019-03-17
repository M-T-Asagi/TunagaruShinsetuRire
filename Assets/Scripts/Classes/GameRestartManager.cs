using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRestartManager : MonoBehaviour
{
    [SerializeField]
    SceneSwitcher sceneSwitcher;

    public void RestartGame()
    {
        GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        if(scoreManager != null)
            scoreManager.GetComponent<ScoreManager>().OnReStartGame();

        sceneSwitcher.ChangeScene();
    }
}
