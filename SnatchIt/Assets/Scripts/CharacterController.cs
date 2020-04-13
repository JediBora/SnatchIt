using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [Header("Audio")]
    AudioSource audioData;
    AudioSource whistleData;
    public AudioSource source1;
    public AudioSource source2;

    [Header("Movement")]
    public float speed;
    Rigidbody2D rb;
    Vector2 movement;

    [Header("AI")]
    public GameObject whistlePrefab;
    public GameObject whistle;
    public List<GameObject> whistles;
    public GameObject threat;
    public PlayerVision vision;

    [Header("Inputs")]
    public string horizontalAxis;
    public string verticalAxis;
    public string whistleInput;

    [Header("SeeThroughWalls")]
    public Shader baseShader;
    public Shader fadeShader;
    //public string threatTag;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        whistles = new List<GameObject>();


    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw(horizontalAxis);
        movement.y = Input.GetAxisRaw(verticalAxis);

        if (Input.GetAxisRaw(horizontalAxis) > 0 || Input.GetAxisRaw(horizontalAxis) < 0 || Input.GetAxisRaw(verticalAxis) > 0 || Input.GetAxisRaw(verticalAxis) < 0)
        {
            Debug.Log("Sound off!");
            //audioData.Play(0);
            source1.Play();
        }

        if (Input.GetAxisRaw(horizontalAxis) == 0 || Input.GetAxisRaw(verticalAxis) == 0)
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
        if (Input.GetButtonDown(whistleInput))
        {
            source2.Play();
        }
        if (Input.GetButtonDown(whistleInput) && vision.enemySeen)
        {

            whistles.Add(whistle);
            whistle = Instantiate(whistlePrefab, transform.position, Quaternion.identity) as GameObject;
            //whistleData.Play(1);

        }
    }
   

}
