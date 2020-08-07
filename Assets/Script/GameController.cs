using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameOverCanvas;
    private Player player;
    private Fade fade;
    private Timer time;
    // Start is called before the first frame update
    void Start()
    {
        time = FindObjectOfType<Timer>();
        player = FindObjectOfType<Player>();
        fade = FindObjectOfType<Fade>();
        panel.SetActive(false);
        gameOverCanvas.SetActive(false);
        StartCoroutine("MudarCena");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setGameOver()
    {
        StartCoroutine("WaitBeforeEnd");

        /*Time.timeScale = 0;
        panel.SetActive(true);
        gameOverCanvas.SetActive(true); */

    }

    public void setRestart()
    {
        player.RestartLife();
        panel.SetActive(false);
        gameOverCanvas.SetActive(false);
        StartCoroutine("MudarCena");
        
        SceneManager.LoadScene("Scene1");
        time.Restart();

        Time.timeScale = 1;
    }

    IEnumerator WaitBeforeEnd()
    {
        yield return new WaitForSeconds(0.3f);


        Time.timeScale = 0;
        panel.SetActive(true);
        gameOverCanvas.SetActive(true);

    }

    IEnumerator MudarCena()
    {

        fade.FadeIn();
        yield return new WaitWhile(() => fade.fume.color.a < 0.9f);

    }

}
