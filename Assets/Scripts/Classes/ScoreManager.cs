using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreNumber = null;

    int score = 0;
    public int Score {
        get { return score; }
        set {
            score = value;
            scoreNumber.text = score.ToString();
        }
    }
}
