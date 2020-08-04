using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontal;
    float vertical;
    Vector3 direction;

    int ceilingLimit = 1;
    int floorLimit = -1;

    public float speed;
    public float timeToAccel = 0.7f;
    float functionVelocity = 0.0f;

    int inversor = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal =  Mathf.SmoothDamp(horizontal, inversor * Input.GetAxis("Horizontal"),ref functionVelocity, timeToAccel);
        vertical = inversor *Input.GetAxis("Vertical");
        
        direction = new Vector3(horizontal, Mathf.Clamp(vertical, floorLimit, ceilingLimit));
        transform.position += direction * speed * Time.deltaTime;

        RaycastCeiling();
        RaycastFloor();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            inversor *= -1;
        }
    }

    void RaycastCeiling()
    {
        Vector2 start = new Vector2(transform.position.x, transform.position.y + 0.8f);
        Vector2 destiny = new Vector2(transform.position.x, transform.position.y + 1.3f);
        RaycastHit2D hit = Physics2D.Linecast(start, destiny);

        if (hit.collider && hit.collider.gameObject.tag == "limit")
                ceilingLimit = 0;
        else
            ceilingLimit = 1;
    }

    void RaycastFloor()
    {
        Vector2 start = new Vector2(transform.position.x, transform.position.y - 0.8f);
        Vector2 destiny = new Vector2(transform.position.x, transform.position.y - 1.3f);
        RaycastHit2D hit = Physics2D.Linecast(start, destiny);

        if (hit.collider && hit.collider.gameObject.tag == "limit")
            floorLimit = 0;
        else
            floorLimit = -1; 
    }
}
