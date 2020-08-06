using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{


    public GameObject painelFume;
    public Image fume;
    public Color[] corTransicao;
    public float step;


    private void Start()
    {
        StartCoroutine("FadeO");
    }
    public void FadeIn()
    {
        painelFume.SetActive(true);
        StartCoroutine("FadeO");
    }

    public void FadeOut()
    {
  
        StartCoroutine("FadeO");
     
    }

    IEnumerator FadeI()
    {

        for (float i = 0; i <= 1; i += step)
        {
            fume.color = Color.Lerp(corTransicao[0], corTransicao[1], i); //Muda a cor 
            yield return new WaitForEndOfFrame();

        }

    }


    IEnumerator FadeO()
    {
        yield return new WaitForSeconds(0.9F);


        for (float i = 0; i <= 1; i += step)
        {

            fume.color = Color.Lerp(corTransicao[1], corTransicao[0], i); //Muda a cor 
            yield return new WaitForEndOfFrame();

        }
        painelFume.SetActive(false);
    }



}

