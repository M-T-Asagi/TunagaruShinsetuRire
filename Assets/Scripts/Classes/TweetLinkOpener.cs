using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class TweetLinkOpener : MonoBehaviour
{
    const string URL_BASE = "https://twitter.com/?status=";

    string url = "";

    private void Start()
    {
        GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        string score = (scoreManager != null) ? scoreManager.GetComponent<ScoreManager>().Score + "も" : "いっぱい";
        url = URL_BASE + "たくさんの人と親切の輪をつなげて、" + score + "の幸せを振りまきました！すごい！みんなでもっと幸せになろ～！ 『つながる！しんせつのわ』 https://unityroom.com/games/tsunasin #unity1week #tunasin";
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
