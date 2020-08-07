﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    GameController gameController;

    float startTime = 60;
    float t;
    string minutes;
    string seconds;

    bool ended = false;
    void Start()
    {
        startTime = 60;
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ended)
        {
            t = startTime - Time.time;
            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f3");

            timer.text = minutes + ":" + seconds;
        }

        if (t < 0.01 && !ended)
        {
            timer.text = "0:00,000";
            ended = true;
            gameController.setGameOver();
        }
    }


    public void Restart()
    {
        startTime = 60;
    }
}
