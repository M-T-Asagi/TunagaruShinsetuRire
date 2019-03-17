using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownCallManager : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    List<AudioClip> voice = null;

    public void CallCount(int index)
    {
        audioSource.PlayOneShot(voice[index]);
    }
}
