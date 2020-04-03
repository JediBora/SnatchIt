using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class EnemyChase : StateBehaviour
{
    private NavMeshAgent2D agent;
    public GameObject threat;
    public Vision visionScript;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent2D>();
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
        agent.destination = threat.transform.position;
        if (visionScript.visibleObjects.Count == 0) 
        {
            SendEvent("Patrol");
        }
    }
}


