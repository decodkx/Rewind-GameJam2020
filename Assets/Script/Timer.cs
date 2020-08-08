using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    GameController gameController;

    float t;
    string minutes;
    string seconds;

    bool ended = false;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        t = 100;
    }

    // Update is called once per frame
    void Update()
    {
        t -= Time.deltaTime; 
        if (!ended)
        {
            //t = startTime - ;
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
}
