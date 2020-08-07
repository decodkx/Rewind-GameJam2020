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

    Rigidbody2D playerRigidbody;
    void Start()
    {
        life = maxLife;
        print(life);
        gameController = FindObjectOfType<GameController>();
        RestartLife();

        playerRigidbody = GetComponent<Rigidbody2D>();
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
    }

    void GainLife()
    {
        life +=1;
        lifes[(life-1)].enabled = true;
    }

    void GameOver()
    {
        if (life <= 0)
        {
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

    public void SetObjectCollision(string collisor)
    {
        TriggerCollision(collisor);
    }


    private void TriggerCollision(string tagCollisior)
    {
        if (tagCollisior == "obstacle" || tagCollisior == "enemy")
        {
            LostLife();
        }
        else if (tagCollisior == "life")
        {
            if (life < maxLife)
            {
                GainLife();
            }
        }

    }

    public bool LifeFull()
    {
        if (life < maxLife)
        {
            return false;
        }
        else
        {
            return true;
        }
    }




}
