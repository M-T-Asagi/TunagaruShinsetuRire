using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetLinkOpener : MonoBehaviour
{
    const string URL_BASE = "https://twitter.com/?status=";

    string url = "";

    private void Start()
    {
        int score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().Score;
        url = URL_BASE + "たくさんの人と親切の輪をつなげて、" + score.ToString() + "もの幸せを振りまきました！すごい！みんなでもっと幸せになろ～！";
    }

    public void OpenLink()
    {
#if UNITY_EDITOR
        Application.OpenURL(url);
#elif UNITY_WEBGL
    Application.ExternalEval(string.Format("window.open('{0}','_blank')", url));
#else
    Application.OpenURL(url);
#endif
    }
}
