using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypointFollower : MonoBehaviour
{

    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;
    [SerializeField] float rotationSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length) {
                currentWaypointIndex = 0;
            }

            _rotateTowardsNextWaypoint();
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }

    private void _rotateTowardsNextWaypoint()
    {
        Debug.Log("rotating the enemy...");
        Vector3 directionToTarget = waypoints[currentWaypointIndex].transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = targetRotation; 
    }
}
