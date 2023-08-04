using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerAI : MonoBehaviour
{
    public Transform[] waypoints;   // Array of waypoints for city roaming
    public Transform garageEntrance;   // Reference to the garage entrance
    public Transform serviceArea;      // Reference to the service area inside the garage

    private UnityEngine.AI.NavMeshAgent navAgent;    // Reference to the NavMeshAgent component
    private int currentWaypointIndex; // Index of the current waypoint
    private bool needsService;        // Flag to check if the car needs service
    private bool isInsideGarage;      // Flag to check if the car is inside the garage

    void Start()
    {
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentWaypointIndex = 0;
        needsService = false;
        isInsideGarage = false;

        // Start car movement
        GoToNextWaypoint();
    }

    void Update()
    {
        // Check if the car has reached its destination (waypoint or garage)
        if (!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
            {
                // Car has reached its destination
                if (isInsideGarage)
                {
                    // Car is inside the garage, perform service/repairs
                    PerformService();
                }
                else
                {
                    // Car has reached a waypoint, continue roaming
                    GoToNextWaypoint();
                }
            }
        }
    }

    void GoToNextWaypoint()
    {
        // Move the car to the next waypoint
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned for car movement!");
            return;
        }

        navAgent.SetDestination(waypoints[currentWaypointIndex].position);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == garageEntrance)
        {
            // Car has entered the garage trigger area
            CheckServiceNeeded();
        }
    }

    void CheckServiceNeeded()
    {
        // Replace this logic with your own conditions to check if the car needs service/repairs
        // For demonstration purposes, let's assume the car needs service 50% of the time
        needsService = Random.value < 0.5f;

        if (needsService)
        {
            // Car needs service, move to the service area in the garage
            navAgent.SetDestination(serviceArea.position);
            isInsideGarage = true;
        }
        else
        {
            // Car does not need service, continue roaming
            GoToNextWaypoint();
        }
    }

    void PerformService()
    {
        // Replace this with your own service/repair logic
        // For demonstration purposes, let's simulate a service delay of 3 seconds
        // and then move the car back to the city
        StartCoroutine(ServiceDelay());
    }

    IEnumerator ServiceDelay()
    {
        yield return new WaitForSeconds(3f);
        isInsideGarage = false;
        GoToNextWaypoint();
    }
}
