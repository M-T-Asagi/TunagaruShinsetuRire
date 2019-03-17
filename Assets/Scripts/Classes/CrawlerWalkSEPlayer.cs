using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerWalkSEPlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    List<AudioClip> actuators;
    [SerializeField]
    List<AudioClip> footsteps;

    public void MoveFoot()
    {
        audioSource.PlayOneShot(actuators[Random.Range(0, actuators.Count)]);
    }

    public void FootStep()
    {
        audioSource.PlayOneShot(footsteps[Random.Range(0, footsteps.Count)]);
    }
}
