using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAI : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public bool isPatrolling;

    
    public Transform[] moveSpots;
    private int randomSpot;

        //for wander
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;



    private void Start()
    {

        if (isPatrolling)
        {
            //for patrolling
            randomSpot = Random.Range(0, moveSpots.Length);
        }
        else {
            //for wander
            moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
    }


    private void Update()
    {


        if (isPatrolling)
        {
            //for patrolling
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position,  speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
                else {
                    waitTime -= Time.deltaTime;
                }


            }
        }
        else
        {
            //for wander
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }


            }
        }


        


        


    }

}
