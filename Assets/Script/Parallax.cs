using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    private float startpos, length, startposy;
    public Camera cam;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        startposy = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        float distt = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector2 (startpos + dist, startposy + distt);

        if (temp > startpos + length) 
            startpos += length;
        else if (temp < startpos - length) 
            startpos -= length;
    }
}
