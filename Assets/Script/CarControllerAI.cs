using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarControllerAI : MonoBehaviour
{
   public Transform[] waypoints;   // Array of waypoints for city roaming
    public Transform garageEntrance;   // Reference to the garage entrance
    public List<ServicePoint> servicePoints;      // Reference to the service area inside the garage

    public float maxSpeed = 30f; // Maximum speed of the car
    public float acceleration = 20f; // Acceleration of the car
    public float deceleration = 30f; // Deceleration of the car
    public float arrivalDistance = 10f; // Distance from the destination to start slowing down
    public float slowdownDistance = 10f; // Distance from the garage entrance to start slowing down
    public float avoidanceDistance = 50f; // Radius to detect nearby cars for avoidance
    public float avoidanceSpeed = 5f;  // Speed when avoiding obstacles (lower than regular speed)


    private NavMeshAgent navAgent;    // Reference to the NavMeshAgent component
    private int currentWaypointIndex; // Index of the current waypoint
    private bool needsService;        // Flag to check if the car needs service
    private bool isInsideGarage;      // Flag to check if the car is inside the garage

    private ServicePoint currentServicePoint;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        currentWaypointIndex = 0;
        needsService = false;
        isInsideGarage = false;
        currentServicePoint = null;

        // Start car movement
        GoToNextWaypoint();
    }

    void Update()
    {
        if (isInsideGarage)
        {
            // Car is inside the garage, perform service/repairs
            PerformService();
            return;
        }

        // Avoid other cars
        AvoidOtherCars();

        // Check if the car is near the garage entrance
        float distanceToEntrance = Vector3.Distance(transform.position, garageEntrance.position);
        if (distanceToEntrance <= slowdownDistance)
        {
            // Slow down the car smoothly as it approaches the garage entrance
            SlowdownCar();

            // Avoid hitting the garage entrance
            Vector3 garageEntranceDirection = garageEntrance.position - transform.position;
            garageEntranceDirection.y = 0f;
            if (garageEntranceDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(-garageEntranceDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
        else
        {
            // Car is not near the garage entrance, continue with regular speed
            navAgent.speed = maxSpeed;
        }

        // Check if the car has reached its destination (waypoint)
        if (!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
            {
                // Car has reached its destination
                GoToNextWaypoint();
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


    void SlowdownCar()
    {
        // Calculate the deceleration factor based on distance to the garage entrance
        float decelerationFactor = Mathf.Clamp01(Vector3.Distance(transform.position, garageEntrance.position) / slowdownDistance);

        // Calculate the desired speed by reducing the max speed based on the deceleration factor
        float desiredSpeed = maxSpeed * decelerationFactor;

        // Smoothly adjust the car's speed based on the desired speed
        navAgent.speed = Mathf.Lerp(navAgent.speed, desiredSpeed, Time.deltaTime * deceleration);
    }

    void AvoidOtherCars()
    {
        // Perform a raycast in the forward direction to detect other cars
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, avoidanceDistance))
        {
            // If another car is detected within the avoidanceDistance
            if (hit.collider.CompareTag("Car"))
            {
                // Slow down or stop the car to avoid collision
                navAgent.speed = Mathf.Lerp(navAgent.speed, avoidanceSpeed, Time.deltaTime);

                // Calculate a direction away from the detected car
                Vector3 avoidanceDirection = (transform.position - hit.collider.transform.position).normalized;

                // Calculate a new destination point to steer away from the detected car
                Vector3 newDestination = transform.position + avoidanceDirection * avoidanceDistance;

                // Set the new destination for the NavMeshAgent to steer away from the detected car
                navAgent.SetDestination(newDestination);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GarageEntrance")
        {
            Debug.Log("garage triggered");
            // Car has entered the garage trigger area
            CheckServiceNeeded();
        }
    } 

    void CheckServiceNeeded()
    {
        // Replace this logic with your own conditions to check if the car needs service/repairs
        // For demonstration purposes, let's assume the car needs service 50% of the time
        needsService = Random.value <1f;

        if (needsService)
        {
            Debug.Log("service needed");
            // Car needs service, move to the service area in the garage
            currentServicePoint = FindAvailableServicePoint();
            if (currentServicePoint != null)
            {
                navAgent.SetDestination(currentServicePoint.transform.position);
                isInsideGarage = true;
                currentServicePoint.TryOccupy();
            }
        }
    }

    ServicePoint FindAvailableServicePoint()
    {
        // Iterate through the service points to find an available one
        foreach (var point in servicePoints)
        {
            if (!point.IsOccupied)
            {
                return point;
            }
        }
        return null;
    }

    void PerformService()
    {
        Debug.Log("car in service");
        // Replace this with your own service/repair logic
        // For demonstration purposes, let's simulate a service delay of 3 seconds
        // and then move the car back to the city
        StartCoroutine(ServiceDelay());
    }
  

    IEnumerator ServiceDelay()
    {
        yield return new WaitForSeconds(3f);
        isInsideGarage = false;
        currentServicePoint.Release();
        yield return new WaitForEndOfFrame();
        Debug.Log("bye bye car");
    }
}
