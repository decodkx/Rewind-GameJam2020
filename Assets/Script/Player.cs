using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    int maxLife = 3;
    int life;
    public List<Image>lifes;
    GameController gameController;
    void Start()
    {
        life = maxLife;
        print(life);
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
        lifes[life].enabled = false;
        print(life);
    }

    void GainLife()
    {
        life +=1;
        lifes[(life-1)].enabled = true;
        print("To com " + life);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(collision.gameObject);
            LostLife();
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            LostLife();
        }
        else if (collision.gameObject.CompareTag("life"))
        {
            if (life < maxLife)
            {
                GainLife();
                Destroy(collision.gameObject);
            }
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

    public void RestartLife()
    {
        foreach(Image img in lifes)
        {
            img.enabled = true;
        }

        life = maxLife; 
    }


}
