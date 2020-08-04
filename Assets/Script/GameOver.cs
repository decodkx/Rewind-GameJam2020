using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
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

    void setGameOver()
    {
        Time.timeScale = 0;
        print("Chegou a mensagem de Game Over");
        panel.enabled = true;
        gameOverCanvas.enabled = true; 

    }

}
