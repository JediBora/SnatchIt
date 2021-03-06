﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class EnemyChase : StateBehaviour
{
    private NavMeshAgent2D agent;
    public GameObject threatPlayer1; 
    public GameObject threatPlayer2;
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
        if (visionScript.objectsInVolume.Contains(threatPlayer1))
        {
            agent.destination = threatPlayer1.transform.position;
        } 
        if (visionScript.objectsInVolume.Contains(threatPlayer2))
        {
            agent.destination = threatPlayer2.transform.position;
        }
        
       
        if (visionScript.objectsInVolume.Count == 0) 
        {
            
            SendEvent("Patrol");
        }
    }
}


