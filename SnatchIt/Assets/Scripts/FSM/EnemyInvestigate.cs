using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class EnemyInvestigate : StateBehaviour
{
    private NavMeshAgent2D agent;
    //public List<GameObject> whistles;
    public CharacterController script;
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
        for (int i = script.whistles.Count - 1; i >= 0; i--)
        {
            GameObject objectInVolume = script.whistles[i];

            // if object has been disabled or deleted, remove it from both lists
            if (objectInVolume == null || !objectInVolume.activeSelf)
            {
                
                    LostSight(objectInVolume);
                    script.whistles.Remove(objectInVolume);
                    
                    continue;
                
            }

            if (script.whistles.Count > 0)
            {
                agent.destination = GameObject.Find("WhistleLocation(Clone)").transform.position;
                //cript.whistles.Remove(script.whistle);
                //Destroy(GameObject.Find("WhistleLocation(Clone)"),4f);

            }
            //if (Input.GetKey(KeyCode.V))
            //{
            //    LostSight(script.whistle);
            //    script.whistles.Remove(script.whistle);
            //}

        }
    }
    void LostSight(GameObject other)
    {
        if (script.whistles.Contains(other))
        {
            script.whistles.Remove(other);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Whistle") 
        {
            Destroy(GameObject.Find("WhistleLocation(Clone)"));
        }
    }
}



