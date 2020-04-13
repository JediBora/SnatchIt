using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]

    private Text itemCounter;

    private int collidedItemValue;
    public AudioSource source3;
    private int moneyAmount;

    // Start is called before the first frame update
    void Start()
    {
        moneyAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        itemCounter.text = "$" + moneyAmount;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown("space") && collision.gameObject.tag.Equals("Item"))
        {
            collidedItemValue = collision.gameObject.GetComponent<Item>().itemValue;

            moneyAmount += collidedItemValue;
            source3.Play();
            Destroy(collision.gameObject);
        }
    }
}
