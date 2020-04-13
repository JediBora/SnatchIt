using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class EnemyInvestigate : StateBehaviour
{
    private NavMeshAgent2D agent;
    //public List<GameObject> whistles;
    public CharacterController script;
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

        print(script.whistles.Count);
        if(script.whistles.Count > 0)
        {
            agent.destination = GameObject.Find("WhistleLocation(Clone)").transform.position;

        }
        
        //cript.whistles.Remove(script.whistle);
        //Destroy(GameObject.Find("WhistleLocation(Clone)"),4f);



        if (script.whistles.Count == 0)
        {
            print("s");
            SendEvent("Patrol");

        }


    }
    public void LostSight()
    {
        if (script.whistles.Contains(script.whistle))
        {
            script.whistles.Remove(script.whistle);
            //owner.SendMessage(visionExitMessage, other, SendMessageOptions.DontRequireReceiver);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Whistle")
        {
            //script.whistle = null;
            // script.whistles.Remove(script.whistle);
            // LostSight();
            alertSound.Play();
            script.whistles.Clear();
            Destroy(GameObject.Find("WhistleLocation(Clone)"));
            changeState = true;
          



        }
    }
}



