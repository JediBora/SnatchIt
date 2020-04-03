using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Vision visionScript;
    public enum State
    {
        Patrolling,
        Attacking,
        Chasing
    }

    public State state;

    

    public Transform[] points;
    private int destPoint = 0;
  
    public float patrolSpeed;
    public float chaseSpeed;

    public GameObject threat;

    private NavMeshAgent2D agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent2D>();
        Patrol();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            Patrol();

        switch (state)
        {
            case State.Patrolling:
                Patrol();
                break;
            case State.Attacking:
                Attacking();
                break;
            case State.Chasing:
                Chase();
                break;
        }
    }
    void Patrol()
    {
        MoveTowardWaypoint();
        
    }

    void Chase()
    {
        
        MoveTowardThreat();
    }

    void Attacking()
    {
        //RegenerateEnergy();
    }


    void MoveTowardThreat()
    {
        agent.destination = threat.transform.position;
        

    }

    void MoveTowardWaypoint()
    {

        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;

        //transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, patrolSpeed * Time.deltaTime);
    }




    void OnVisionEnter(Collider2D other)
    {
        threat = other.gameObject;
        
        state = State.Chasing;
    }



    void OnVisionExit(Collider2D other)
    {
        Debug.Log("Lost Player!!!!");
        state = State.Patrolling;
        threat = null;
    }
}
