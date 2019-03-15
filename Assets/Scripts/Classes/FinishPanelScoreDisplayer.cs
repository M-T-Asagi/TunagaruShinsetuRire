using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishPanelScoreDisplayer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scorePanel = null;

    // Start is called before the first frame update
    void Start()
    {
        scorePanel.text = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().Score.ToString();
    }
}
