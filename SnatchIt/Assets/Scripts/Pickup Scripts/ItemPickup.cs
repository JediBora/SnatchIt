using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]

    private Text itemCounter;

    private int collidedItemValue;

    private int moneyAmount;

    // Start is called before the first frame update
    void Start()
    {
        moneyAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        itemCounter.text = "Money: " + moneyAmount;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown("space") && collision.gameObject.tag.Equals("Item"))
        {
            collidedItemValue = collision.gameObject.GetComponent<Item>().itemValue;

            moneyAmount += collidedItemValue;

            Destroy(collision.gameObject);
        }
    }
}
