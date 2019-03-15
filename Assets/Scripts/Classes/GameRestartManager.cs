using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRestartManager : MonoBehaviour
{
    [SerializeField]
    SceneSwitcher sceneSwitcher;

    public void RestartGame()
    {
        GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().OnReStartGame();
        sceneSwitcher.ChangeScene();
    }
}
