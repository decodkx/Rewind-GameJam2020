using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Image panel;
    public Image gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        panel.enabled = false;
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PausePlay()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }

    }

    public void setGameOver()
    {
        Time.timeScale = 0;
        print("Chegou a mensagem de Game Over");
        panel.enabled = true;
        gameOverCanvas.enabled = true;

    }


}
