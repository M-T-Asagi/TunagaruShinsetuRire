﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    SceneObject scene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);   
    }
}
