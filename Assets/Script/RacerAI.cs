using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RacerAI : MonoBehaviour
{
    public LayerMask obstacleLayer; // Layer mask for obstacles
    public float brakingDistance = 3f; // Distance at which the AI car should start braking
    public float slowDownDistance = 5f;
    public float maxBrakeForce = 30f; // Maximum brake force
    private float currentDuration;


    public float maxAcceleration = 10f; // Maximum acceleration
    public float targetSpeed = 20f; // Target speed
    public bool playerInCar;
    private bool raceEnds;
    public GameObject playerCar;
    private NavMeshAgent agent;

    public Transform[] waypoints; // Array of waypoint transforms
    private int currentWaypointIndex = 0;

    void Update()
    {
        if(!playerInCar)
        { 
            if (agent != null)
            {
                agent.enabled = false; // Disable NavMeshAgent movement
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (agent != null)
            {
                agent.enabled = true; // Enable NavMeshAgent movement
            }
            Debug.Log("Player is in Car");
            playerInCar = true;
            StartCoroutine(Racing());
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWaypointIndex = 0;
        currentWaypointIndex = 0;
        raceEnds = false;
        playerInCar = false;  
    }


    IEnumerator Racing()
    {
        Debug.Log("Racing Start");
        yield return new WaitForSeconds(10f); //count down
        GoToNextWaypoint();
        while (!raceEnds && playerInCar)
        {
            CheckPlayerRange();
            AvoidCollisions();
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // Car has reached its destination
                    GoToNextWaypoint();
                }
            }
        }
        if (raceEnds)
        {
            Brake();
            yield return new WaitForSeconds(2f);
            playerInCar = false;
            raceEnds = false;
        }
        yield return new WaitForEndOfFrame();
        Debug.Log("Racing End");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("raceline passed");
            raceEnds = true;
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

        agent.SetDestination(waypoints[currentWaypointIndex].position);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    private void CheckPlayerRange()
    {
        if (playerCar != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, playerCar.transform.position);

            if (distanceToTarget <= brakingDistance)
            {
                Brake();
            }
            if (distanceToTarget <= slowDownDistance)
            {
                SlowDown();
            }
            else
            {
                Accelerate();
            }

            agent.SetDestination(playerCar.transform.position);
        }
    }

    private void AvoidCollisions()
    {
        // Cast a ray in front of the AI car to detect obstacles
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, agent.radius * 2, obstacleLayer))
        {
            Vector3 avoidDir = Vector3.Cross(hit.normal, Vector3.up);
            Vector3 newTarget = transform.position + (transform.forward + avoidDir) * 10f;

            agent.SetDestination(newTarget);
        }
    }

    private void Brake()
    {
        float brakeForce = Mathf.Lerp(0, maxBrakeForce, 1f - (brakingDistance - agent.remainingDistance) / brakingDistance);
        agent.velocity = Vector3.Lerp(agent.velocity, Vector3.zero, brakeForce * Time.deltaTime);
    }

    private void Accelerate()
    {
        float currentSpeed = agent.velocity.magnitude;
        float acceleration = Mathf.Clamp(targetSpeed - currentSpeed, 0f, maxAcceleration);
        Vector3 desiredVelocity = transform.forward * (currentSpeed + acceleration * Time.deltaTime);
        agent.velocity = Vector3.ClampMagnitude(desiredVelocity, currentSpeed + acceleration * Time.deltaTime);
    }

    private void SlowDown()
    {
        float speedReduction = (brakingDistance - slowDownDistance) / brakingDistance;
        agent.speed = targetSpeed * speedReduction;
    }
    private void Stop()
    {
        agent.speed = 0;
    }

}
