using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Scripts")]
    public Text itemPickupText; 
    public Text itemPickupText1;
    public ItemPickup itemPickupScript; 
    public ItemPickup itemPickupScript1;
    public AudioSource playerCaught;
    // Start is called before the first frame update
    void Start()
    {
        //itemPickupScript = GetComponent<ItemPickup>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCaught.Play();
            player1Canvas.SetActive(true);
            player1.enabled = false;
            player1Caught = true;
            //itemPickupText.text = "$" + (itemPickupScript.moneyAmount - 10);
            StartCoroutine(SpawnPlayer());
        }
        if (collision.gameObject.tag == "Player2")
        {
            playerCaught.Play();
            player2Canvas.SetActive(true);
            player2.enabled = false;
            player2Caught = true;
           // itemPickupText1.text = "$" + (itemPickupScript1.moneyAmount - 10);
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
