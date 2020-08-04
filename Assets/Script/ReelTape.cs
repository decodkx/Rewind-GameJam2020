using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelTape : MonoBehaviour
{
    Animator anim;
    float coil;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            coil += 0.0005f;
            anim.SetFloat("process", coil);
        }

    }
}
