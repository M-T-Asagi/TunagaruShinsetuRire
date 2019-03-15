using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSettings : MonoBehaviour
{
    [SerializeField]
    int gettingScore = 1000;

    public int GettingScore { get { return gettingScore; } }
}
