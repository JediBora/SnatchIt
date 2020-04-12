using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    AudioSource audioData;
    AudioSource whistleData;
    public AudioSource source1;
    public AudioSource source2;
    public float speed;
    Rigidbody2D rb;
    Vector2 movement;
    public NavMeshAgent2D agent;
    public GameObject whistlePrefab;
    public GameObject whistle;
    public List<GameObject> whistles;
    public GameObject threat;
    public PlayerVision vision;

    //public string threatTag;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioData = GetComponent<AudioSource>();
        whistleData = GetComponent<AudioSource>();
        whistles = new List<GameObject>();

        
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            Debug.Log("Sound off!");
            //audioData.Play(0);
            source1.Play();
        }

        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            //audioData.Stop();
            source1.Stop();
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
            source2.Play();
        }
        if (Input.GetKeyDown(KeyCode.R) && vision.enemySeen)
        {
            
            whistles.Add(whistle);
            whistle = Instantiate(whistlePrefab, transform.position, Quaternion.identity) as GameObject;
            //whistleData.Play(1);
            
        }
    }

    void OnWhistleEnter(Collider2D other)
    {
        
        threat = other.gameObject;

    }
    void OnWhistleExit(Collider2D other)
    {
        threat = null;
    }

}
