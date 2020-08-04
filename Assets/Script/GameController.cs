using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false) ;
        gameOverCanvas.SetActive(false);
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
        panel.SetActive(true);
        gameOverCanvas.SetActive(true);

    }


}
