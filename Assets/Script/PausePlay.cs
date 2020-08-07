using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePlay : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    public Sprite pause;
    public Sprite play;
    void Start()
    {
        button.image.sprite = pause;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPlayPause()
    {
        print("apertei");
        if(Time.timeScale == 0)
        {
            button.image.sprite = play;
            Time.timeScale = 1;
        }
        else
        {
            button.image.sprite = pause;
            Time.timeScale = 0;
        }
    }
}
