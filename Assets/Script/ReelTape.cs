using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelTape : MonoBehaviour
{
    Animator anim;
    Move scriptMovement;
    float reel;

    void Start()
    {
        scriptMovement = GetComponent<Move>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(scriptMovement.withGas) 
        reel += 0.0035f * Input.GetAxis("Horizontal");
        reel = Mathf.Clamp(reel, 0, 0.91f);

        switch (scriptMovement.inversor)
        {
            case (1):
                anim.SetFloat("process", reel);
                if (reel > 0.9f)
                {
                    scriptMovement.inversor = -1;
                    anim.SetBool("flip", true);
                }
                else scriptMovement.withGas = true;
                break;
            case (-1):
                anim.SetFloat("process", 1 - reel);
                if (reel < 0.08f)
                {
                    scriptMovement.inversor = 1;
                    anim.SetBool("flip", false);
                }
                break;
        }
    }
}
