using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePath : MonoBehaviour
{

    //pathing code provided by MoreBBlakeyyy on Youtube: https://www.youtube.com/watch?v=4mzbDk4Wsmk&t=443s
    //I tried to follow the code from the shmup program we did but it did not work

    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;


    private void Start()
    {
        targetPoint = 0;

        //transform.position = patrolPoints[targetPoint].transform.position;
    }


    private void Update()
    {
                                                // gets the position of the enemy to go to the position of the next point in the array
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);


        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt(); // once the nemey reaches the position of a target point, runs this code
        }

    }


    void increaseTargetInt()
    {
        targetPoint++; // adds 1 to the current target point to correctly incriment it for the enemy to follow the next point in the seris

        if (targetPoint >= patrolPoints.Length) 
        {
            targetPoint = 0; // once the enemy reaches it's final point, its next target point is zero to prevent a runtime error
        }
    }

}







  







   



