﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{

    // Start is called before the first frame update
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying=false;
        Application.Quit();

    }
}
