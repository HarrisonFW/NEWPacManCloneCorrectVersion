using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePath : MonoBehaviour
{

    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;


    private void Start()
    {
        targetPoint = 0;

        
    }


    private void Update()
    {
        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }



        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

        
    }


    void increaseTargetInt()
    {
        targetPoint++;

        if(targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }












    /*[SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;


    //params
    int waypointIndex = 0;
    [SerializeField] float enemyMoveSpeed = 2f;

    //cached refs
    List<Transform> waypoints;
   

    private void Start()
    {
        // waypoint = BluePath.GetWayPoints();

        public List<Transform> GetWayPoints()
        {
            var waveWaypoints = new List<Transform>();

            foreach (Transform waypoint in pathPrefab.transform)
            {
                waveWaypoints.Add(waypoint);
            }

            return waveWaypoints;
        }

    }

    private void Update()
    {
        MoveEnemyOnPath();
    }

    private void MoveEnemyOnPath()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetWaypointPosition = waypoints[waypointIndex].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetWaypointPosition, enemyMoveSpeed * Time.deltaTime);

            if (transform.position == targetWaypointPosition)
            {
                waypointIndex++;
            }
        }

       
    }
*/


}
