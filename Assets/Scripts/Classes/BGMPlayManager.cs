using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayManager : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    GameStateManager gameStateManager = null;

    // Start is called before the first frame update
    void Start()
    {
        gameStateManager.stateChanged += (object sender, GameStateManager.StateChangedEventArgs args) =>
        {
            if (args.newState == GameStateManager.State.GamePlaying)
                audioSource.Play();
        };
    }
}
