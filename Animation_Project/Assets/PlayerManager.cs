﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameOver;
    public GameObject gamePanel;
    void Start()
    {        
        gameOver=false;
        Time.timeScale=1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale=0;
            gamePanel.SetActive(true);
        } 
    }
}
