using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RacerAI : MonoBehaviour
{
    private string currentState;
    private string nextState;
    public LayerMask obstacleLayer; // Layer mask for obstacles
    public float brakingDistance = 10f; // Distance at which the AI car should start braking
    public float maxBrakeForce = 30f; // Maximum brake force
    private float currentDuration;


    public float maxAcceleration = 10f; // Maximum acceleration
    public float targetSpeed = 20f; // Target speed
    public Transform RaceLine;
    public bool playerInCar;
    private bool raceEnds;
    public GameObject playerCar;
    private NavMeshAgent agent;

    public Transform[] waypoints; // Array of waypoint transforms
    private int currentWaypointIndex = 0;

    private void SwitchState()
    {
        StartCoroutine(currentState);
    }

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        currentWaypointIndex = 0;
        playerInCar = false;
        raceEnds = true;

        currentState = "Idle";
        nextState = currentState;
        SwitchState();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Player is in Car");
        //    playerInCar = true;
        //}

        if (currentState != nextState)
        {
            Debug.Log("state changed");
            currentState = nextState;
        }

    }

   
    IEnumerator Idle()
    {
        Debug.Log("Idle start");
        while (raceEnds && !playerInCar)
        {
            currentDuration += Time.deltaTime;
            Stop();
            yield return new WaitForEndOfFrame();
            if (currentDuration > 10f)
            {
                Debug.Log("Player is in Car");
                playerInCar = true;
            }
        }
        if (playerInCar)
        {
            agent.speed = maxAcceleration;
            currentDuration = 0;
            // Add in some count down trigger to signal to player race starting
            yield return new WaitForSeconds(3f);//waiting for countdown to start racing
            raceEnds = false;
            Debug.Log("going to next state");
            nextState = "Racing";
        }
        Debug.Log("Idle End");
        Debug.Log("Next state: " + nextState);
        Debug.Log("current state: " + currentState);
        yield return new WaitForEndOfFrame();
        SwitchState();
    }
    IEnumerator Racing()
    {
        Debug.Log("Racing start");
        GoToNextWaypoint();
        while (playerInCar && !raceEnds)
        {
            CheckPlayerRange();
            AvoidCollisions();

            // Check if the car has reached its destination (waypoint)
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
            Debug.Log("going to next state");
            nextState = "End";
        }
        Debug.Log("Racing End");
        yield return new WaitForEndOfFrame();
        SwitchState();
    }
    IEnumerator End()
    {
        GoToNextWaypoint();
        
        while (raceEnds && playerInCar)
        {
            currentDuration += Time.deltaTime;
            Brake();
            if(currentDuration >5f)
            {
                currentDuration = 0;
                playerInCar = false;
                Debug.Log("going to next state");
                nextState = "Idle";
            }
        }
        yield return new WaitForSeconds(1f);
        SwitchState();
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == RaceLine)
        {
            Debug.Log("Race Ends");
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
    private void Stop()
    {
        agent.speed = 0;
    }
    
}
