using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeShader : MonoBehaviour
{
    public Shader baseShader;
    public Shader fadeShader;
    public GameObject player1; public GameObject player2;
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the trigger");
            player1.GetComponent<Renderer>().material.shader = fadeShader;
            player1.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        if (collision.gameObject.tag == "Player2")
        {
            Debug.Log("Player has entered the trigger");
            player2.GetComponent<Renderer>().material.shader = fadeShader;
            player2.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has exited the trigger");
            player1.GetComponent<Renderer>().material.shader = baseShader; 
            player1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if (collision.gameObject.tag == "Player2")
        {
            Debug.Log("Player has entered the trigger");
            player2.GetComponent<Renderer>().material.shader = baseShader;
            player2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

    
}