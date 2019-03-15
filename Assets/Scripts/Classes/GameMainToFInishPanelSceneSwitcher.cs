using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainToFInishPanelSceneSwitcher : MonoBehaviour
{
    [SerializeField]
    SceneSwitcher sceneSwitcher = null;

    [SerializeField]
    TimeManager timeManager = null;

    // Start is called before the first frame update
    void Start()
    {
        timeManager.gameFinish += (object sender, TimeManager.GameFinishEventArgs args) =>
        {
            sceneSwitcher.ChangeScene();
        };
    }
}
