using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class EnemyInvestigate : StateBehaviour
{
    private NavMeshAgent2D agent;
    //public List<GameObject> whistles;
    public CharacterController characterScriptPlayer1;
    public CharacterController characterScriptPlayer2;
    public bool changeState = false;
    public AudioSource alertSound;

    private void Start()
    {
       
        agent = GetComponent<NavMeshAgent2D>();
    }
    // Called when the state is enabled
    void OnEnable()
    {
        Debug.Log("Started *State*");
    }

    // Called when the state is disabled
    void OnDisable()
    {
        Debug.Log("Stopped *State*");
    }

    // Update is called once per frame
    void Update()
    {

        print(characterScriptPlayer1.whistles.Count);
        if (characterScriptPlayer1.whistles.Count > 0 || characterScriptPlayer2.whistles.Count > 0)
        {
            agent.destination = GameObject.Find("WhistleLocation(Clone)").transform.position;

        }

       

        if (characterScriptPlayer1.whistles.Count == 0 && characterScriptPlayer2.whistles.Count == 0)
        {

            SendEvent("Patrol");

        }


    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Whistle")
        {
          
            alertSound.Play();
            characterScriptPlayer1.whistles.Clear();
            characterScriptPlayer2.whistles.Clear();
            Destroy(GameObject.Find("WhistleLocation(Clone)"));
          




        }
    }
}



