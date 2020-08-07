using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public Player player;
    bool crash = false;
    Animator anim;
    public BoxCollider2D col;
    public GameObject light;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>();
        if (gameObject.CompareTag("obstacle"))
        {
            col = GetComponent<BoxCollider2D>();
            anim = GetComponent<Animator>();
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
                Destroy(light);
            }
           /*else if (this.gameObject.CompareTag("life"))
            {
                bool lifeFull = player.LifeFull();
                if (lifeFull == false)
                {
                    Destroy(this.gameObject);
                }
                print("Vida esta " + lifeFull);
            } */
            else
            {
                Destroy(this.gameObject);
            }
            audio.Play();
            print("Tocou o audio");
            player.SetObjectCollision(this.tag);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.CompareTag("life"))
        {
            bool lifeFull = player.LifeFull();
            if (lifeFull == false)
            {
                Destroy(this.gameObject);
            }
            
        }

        player.SetObjectCollision(this.tag);
    }
}

