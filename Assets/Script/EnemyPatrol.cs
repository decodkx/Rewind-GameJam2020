using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    public Transform[] moveSpotsRewind;
    private int maxSpots;

    private Move move;
    
    private int index = 0;
    void Start()
    {
        move = FindObjectOfType<Move>();
        maxSpots = moveSpots.Length;

        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        movePath();
    }

    void movePath()
    {
        switch (move.inversor)
        {
            case 1:
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[index].position, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, moveSpots[index].position) < 0.2f)
                {

                    GenerateSpot();
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                break;

            case -1:
                transform.position = Vector2.MoveTowards(transform.position, moveSpotsRewind[index].position, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, moveSpotsRewind[index].position) < 0.2f)
                {
           
                    GenerateSpot();
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                break;

        }
            

    }

    private void GenerateSpot()
    {
        setMaxSpots();

        if (index < (maxSpots - 1))
        {
            index = index + 1;
            
        }
        else if(index >=(maxSpots - 1))
        {
            index = 0;
        }

    }

    private void setMaxSpots()
    {
        if (move.inversor == 1)
        {
            maxSpots = moveSpots.Length;
        }
        else
        {
            maxSpots = moveSpotsRewind.Length;
        }

    }

}
