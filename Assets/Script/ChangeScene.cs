using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    //private SomManagement somManagement;
    public string cenaDestino;
    private Fade fade;
    // Start is called before the first frame update
    void Start()
    {
        //somManagement = FindObjectOfType(typeof(SomManagement)) as SomManagement;
        fade = FindObjectOfType<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Changescene()
    {
        if (Time.timeScale == 0){
            Time.timeScale = 1;
        }
        //somManagement.TrocarMusic(somManagement.MusicaJogo, cenaDestino, true);
        //StartCoroutine("MudarCena");
        SceneManager.LoadScene(cenaDestino);

    }
    /*IEnumerator MudarCena()
    {

        fade.FadeIn();
        yield return new WaitWhile(() => fade.fume.color.a < 0.9f);
        somManagement.TrocarMusic(somManagement.MusicaJogo, cenaDestino, true);
        SceneManager.LoadScene(cenaDestino);

    } */

}
