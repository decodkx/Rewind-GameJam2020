using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject image;
    public Button button;
    public GameObject panel;


    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        //StartCoroutine("WaitBeforeWin");
        
    }

    //IEnumerator WaitBeforeWin()
    //{
    //    yield return new WaitForSeconds(0.3f);



    //    //image.SetActive(true);
        

    //}
}
