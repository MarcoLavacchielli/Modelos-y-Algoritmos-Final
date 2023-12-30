using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatflorm : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float changeDirectionDelay;

    private Transform destinationTarget, departTarget;
    private int currentWaypointIndex = 0;
    private float startTime;
    private float journeyLength;
    bool isWaiting;

    void Start()
    {
        departTarget = waypoints[currentWaypointIndex];
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        destinationTarget = waypoints[currentWaypointIndex];

        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {

        if (!isWaiting)
        {
            if (Vector3.Distance(transform.position, destinationTarget.position) > 0.01f)
            {
                float distCovered = (Time.time - startTime) * speed;
                float fractionOfJourney = distCovered / journeyLength;
                transform.position = Vector3.Lerp(departTarget.position, destinationTarget.position, fractionOfJourney);
            }
            else
            {
                isWaiting = true;
                StartCoroutine(ChangeDelay());
            }
        }

    }

    void ChangeDestination()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        departTarget = destinationTarget;
        destinationTarget = waypoints[currentWaypointIndex];
    }

    IEnumerator ChangeDelay()
    {
        yield return new WaitForSeconds(changeDirectionDelay);
        ChangeDestination();
        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
        isWaiting = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }
}
