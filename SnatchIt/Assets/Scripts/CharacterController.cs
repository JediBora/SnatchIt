using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    AudioSource audioData;
    public float speed;
    Rigidbody2D rb;
    Vector2 movement;
    //public NavMeshAgent2D agent;
    public GameObject whistlePrefab;
     public GameObject whistle;
    public List <GameObject> whistles;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioData = GetComponent<AudioSource>();
        whistles = new List<GameObject>();
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Horizontal")|| Input.GetButtonDown("Vertical"))
        {
            Debug.Log("Sound off!");
            audioData.Play();
        }

        if(Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            audioData.Stop();
        }

        Whistle();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void Whistle()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            whistle = Instantiate(whistlePrefab,transform.position,Quaternion.identity);
            whistles.Add(whistle);

        }

    }
}
