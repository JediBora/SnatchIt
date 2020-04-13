using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class EnemyPatrol : StateBehaviour
{
   
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent2D agent;
    public Vision visionScript;
    public CharacterController characterScript;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent2D>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        // agent.autoBraking = false;

        GotoNextPoint();
    }
    // Called when the state is enabled
    void OnEnable () {
		Debug.Log("Started *State*");
	}
 
	// Called when the state is disabled
	void OnDisable () {
		Debug.Log("Stopped *State*");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
        if(visionScript.objectsInVolume.Count > 0) 
        {
            SendEvent("Chase");
        }
        if (characterScript.whistles.Count > 0) 
        {
            SendEvent("Investigate");
        }
    }
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


}


