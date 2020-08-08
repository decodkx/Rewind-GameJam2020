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
    bool crash = false;
    Animator anim;


    void Start()
    {
        panel.SetActive(false);
        image.SetActive(false);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.CompareTag("win"))
        {
            crash = true;
            anim.SetBool("crash", crash);
            StartCoroutine("WaitBeforeWin");
        }
    }

    IEnumerator WaitBeforeWin()
    {
        yield return new WaitForSeconds(0.3f);


        Time.timeScale = 0;
        panel.SetActive(true);
        //image.SetActive(true);
        

    }
}
