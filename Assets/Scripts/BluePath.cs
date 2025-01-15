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

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);


        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }

    }


    void increaseTargetInt()
    {
        targetPoint++;

        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }

}







  







   



