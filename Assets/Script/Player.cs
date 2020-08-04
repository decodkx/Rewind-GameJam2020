using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    int life = 3;
    public List<Image> lifes;
    GameController gameController;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        RestartLife();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LostLife()
    {
        life -= 1;
        GameOver();
        if (life < 3 && life >0) //Dps tirar
        {
            lifes[life].enabled = false;
        }
        print(life);
    }

    void GainLife()
    {
        life +=1;
        if (life <= 3) //Dps tirar
        {
            lifes[(life-1)].enabled = true;
        }
        
        print("To com " + life);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(collision.gameObject);
            LostLife();
        }
        else if (collision.gameObject.CompareTag("life"))
        {
            Destroy(collision.gameObject);
            GainLife();
        }
    }

    void GameOver()
    {
        if (life <= 0)
        {
            print("GameOver");
            gameController.setGameOver();
        }
    }

    void RestartLife()
    {
        foreach(Image img in lifes)
        {
            img.enabled = true;
        }
    }


}
