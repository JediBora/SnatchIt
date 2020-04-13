using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeShader : MonoBehaviour
{
    public Shader baseShader;
    public Shader fadeShader;
    public GameObject player;
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the trigger");
            player.GetComponent<Renderer>().material.shader = fadeShader;
            player.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has exited the trigger");
            player.GetComponent<Renderer>().material.shader = baseShader; 
            player.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

    
}