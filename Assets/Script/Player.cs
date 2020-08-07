using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    int maxLife = 3;
    int life;
    public List<Image>lifes;

    GameController gameController;

    Rigidbody2D playerRigidbody;

    #region To shake things up                  
    Vector3 cameraInitialPosition;
    public float shakeMagnetude = 0.01f, shakeTime = 0.5f;
    public Cam mainCamera;
    #endregion

    void Start()
    {
        life = maxLife;
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
        mainCamera.StartShake(0.3f, 0.08f);
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

    public void Shake()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnetude * 2 - shakeMagnetude;
        float cameraShakingOffsetY = Random.value * shakeMagnetude * 2 - shakeMagnetude;
        Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
        cameraIntermadiatePosition.x += cameraShakingOffsetX;
        cameraIntermadiatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermadiatePosition;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
    }

}
