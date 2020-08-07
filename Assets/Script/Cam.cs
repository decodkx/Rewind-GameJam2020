using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform playerTranform;
    private Camera cam;
    public float speedCam;
    // limetes das cameras
    public Transform LimiteCamEsquerdo;
    public Transform LimiteCamDireito;
    public Transform LimiteCamCima;
    public Transform LimiteCamBaixo;

    private float shakeTimeRemaining, shakePower, xAmount, yAmount;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            StartShake(0.3f, 0.08f);
        }
    }

    private void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            xAmount = Random.Range(-1f, 1f) * shakePower;
            yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);
        }
        /*Vector3 posCam = new Vector3(playerTranform.position.x, playerTranform.position.y, cam.transform.position.z);
        cam.transform.position = posCam;*/

        float posCamX = playerTranform.position.x;
        float posCamY = playerTranform.position.y;

        //if (cam.transform.position.x < LimiteCamEsquerdo.position.x && playerTranform.position.x < LimiteCamEsquerdo.position.x)
        //{
        //    posCamX = LimiteCamEsquerdo.position.x;
        //}
        //else if (cam.transform.position.x > LimiteCamDireito.position.x && playerTranform.position.x > LimiteCamDireito.position.x)
        //{
        //    posCamX = LimiteCamDireito.position.x;
        //}

        //if (cam.transform.position.y < LimiteCamBaixo.position.y && playerTranform.position.y < LimiteCamBaixo.position.y)
        //{
        //    posCamY = LimiteCamBaixo.position.y;
        //}
        //else if (cam.transform.position.y > LimiteCamCima.position.y && playerTranform.position.y > LimiteCamCima.position.y)
        //{
        //    posCamY = LimiteCamCima.position.y;
        //}

        Vector3 posCam = new Vector3(posCamX, posCamY, cam.transform.position.z);
        cam.transform.position = Vector3.Lerp(cam.transform.position, posCam, speedCam * Time.deltaTime);
    }

    public void StartShake(float lenght, float power)
    {
        shakeTimeRemaining = lenght;
        shakePower = power;
    }
}
