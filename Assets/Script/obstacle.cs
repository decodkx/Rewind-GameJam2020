using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public Player player;
    bool crash = false;
    Animator anim;
    public BoxCollider2D col;

    void Start()
    {
        player = FindObjectOfType<Player>();
        if (this.tag == "obstacle")
        {
            col = this.GetComponent<BoxCollider2D>();
            anim = this.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("obstacle"))
            {
                crash = true;
                anim.SetBool("crash", crash);
                Destroy(col);
            }
           else if (this.gameObject.CompareTag("life"))
            {
                bool lifeFull = player.LifeFull();
                if (lifeFull == false)
                {
                    Destroy(this.gameObject);
                }
                print("Vida esta " + lifeFull);
            }
            else
            {
                Destroy(this.gameObject);
            }
        
            player.SetObjectCollision(this.tag);
        }
    }
}

