using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [Header("Canvas UI")]
    public GameObject player1Canvas;
    public GameObject player2Canvas;

    [Header("Players")]
    public CharacterController player1;
    public CharacterController player2;

    [Header("Floats")]
    public float jailTime = 2;

    [Header("Bools")]
    public bool player1Caught = false;
    public bool player2Caught = false;

    [Header("Locations")]
    public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player1Canvas.SetActive(true);
            player1.enabled = false;
            player1Caught = true;
            StartCoroutine(SpawnPlayer());
        }
        if (collision.gameObject.tag == "Player2")
        {
            player2Canvas.SetActive(true);
            player2.enabled = false;
            player2Caught = true;
            StartCoroutine(SpawnPlayer());
        }
    }
    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(jailTime);
        if (player1Caught)
        {
            player1.transform.position = spawn.position;
            player1Canvas.SetActive(false);
            player1.enabled = true;
            player1Caught = false;

        }
        if (player2Caught)
        {
            player2.transform.position = spawn.position;
            player2Canvas.SetActive(false);
            player2.enabled = true;
            player2Caught = false;
        }

    }
}
