using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainToFInishPanelSceneSwitcher : MonoBehaviour
{
    [SerializeField]
    SceneSwitcher sceneSwitcher = null;

    public void SceneSwitch()
    {
        sceneSwitcher.ChangeScene();
    }
}
