using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeteor : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public Move moveScript;
    public float speed = 5; 

    bool rewind = false;
    Vector3 direction = new Vector2(1,1); 
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float closeness = Vector2.Distance(player.transform.position, this.transform.position);
        if(moveScript.inversor == -1 && 7f > closeness)
        {
            rewind = true;
        }

        if(rewind)
        {
            anim.SetBool("go", rewind);
            transform.position += direction * Time.deltaTime * speed;
        }
    }
}
