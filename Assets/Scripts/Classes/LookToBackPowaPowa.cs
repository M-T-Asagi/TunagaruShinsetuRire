using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToBackPowaPowa : MonoBehaviour
{
    [SerializeField]
    Transform powapowa;

    void Start()
    {
        powapowa.LookAt(Camera.main.transform.position, Vector3.up);
    }
}
