using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyspad : MonoBehaviour
{
    [SerializeField] NavMeshAgent ai;
    public float moveSpeed = 3f;
    public float idleMoveSpeed = 1.5f;
    public Transform[] waypoints;  // Define waypoints for idle movement
    public float detectionRadius = 10f;
    public LayerMask playerLayer;

    private Transform player;
    private bool isChasing = false;
    private int currentWaypoint = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SetRandomWaypoint();  // Start with a random waypoint for idle movement
    }

    void Update()
    {
        // Check if the player is within the detection radius
        if (Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            // Check if there are no obstacles between the enemy and the player
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.position - transform.position, out hit, detectionRadius, playerLayer))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    // Player is in sight, start chasing
                    isChasing = true;
                }
                else
                {
                    // Player is not in sight, stop chasing
                    isChasing = false;
                }
            }
        }

        // If chasing, move towards the player; otherwise, move freely
        if (isChasing)
        {
            MoveTowardsPlayer();
        }
        else
        {
            MoveFreely();
        }
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction to move towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Move the enemy towards the player
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void MoveFreely()
    {
        /*
        // Move the enemy towards the current waypoint
        Vector3 direction = (waypoints[currentWaypoint].position - transform.position).normalized;
        transform.Translate(direction * idleMoveSpeed * Time.deltaTime);

        // Check if the enemy reached the waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            SetRandomWaypoint();
        }
        */
        Vector3 direction = waypoints[currentWaypoint].position;
        ai.destination = direction;
        if(Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            SetRandomWaypoint();
        }

    }

    void SetRandomWaypoint()
    {
        // Set a random waypoint for idle movement
        currentWaypoint = Random.Range(0, waypoints.Length);
    }
}
