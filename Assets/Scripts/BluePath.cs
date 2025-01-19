using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePath : MonoBehaviour
{

    //pathing code provided by MoreBBlakeyyy on Youtube: https://www.youtube.com/watch?v=4mzbDk4Wsmk&t=443s
    //I tried to follow the code from the shmup program we did but it did not work

    //Cashed References

    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;

    public bool isActive = true; //ChatGPT also helped in providing the code for activating the purple
                                 // Booman after collecting 48 pills

    private void Start()
    {
        targetPoint = 0;

        //transform.position = patrolPoints[targetPoint].transform.position;
    }


    private void Update()
    {
        if (!isActive) // if the "isActive" boolean is false, this statement returns and dosen't execute the rest of the code, this is because every booman has this
                       // boolean in the inspector, just the only one with it not ticked is the purple booman
        {
            return;
        }

        MoveEnemy();
        
        // gets the position of the enemy to go to the position of the next point in the array
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);


        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt(); // once the nemey reaches the position of a target point, runs this code
        }

        


    }


    void increaseTargetInt() // this adds 1 to the "target point" number so that each Booman knows the correct next target on their path to go to
    {
        targetPoint++; // adds 1 to the current target point to correctly incriment it for the enemy to follow the next point in the seris

        if (targetPoint >= patrolPoints.Length) 
        {
            targetPoint = 0; // once the enemy reaches it's final point, its next target point is zero to prevent a runtime error
        }
    }

    private void MoveEnemy() //sends a message to the debug log to let developer know that the enmemies are in fact moving
    {
        Debug.Log(gameObject.name + " is moving");
    }




}







  







   



