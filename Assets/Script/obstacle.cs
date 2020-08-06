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

    void Start()
    {
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
            player.SetObjectCollision(this.tag);
            if (this.gameObject.CompareTag("obstacle"))
            {
                crash = true;
                anim.SetBool("crash", crash);
                Destroy(col);
                Destroy(light);
            }
            else
                Destroy(this.gameObject);
        }
    }
}

