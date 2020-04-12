using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private string itemName;
    public int itemValue;

    // Start is called before the first frame update
    void Start()
    {
        itemName = name.Substring(0, 5);

        switch (itemName)
        {
            case "DeadpanLady":
                itemValue = 1;
                break;

            case "TheScream":
                itemValue = 2;
                break;

            case "ArmlessSatue":
                itemValue = 3;
                break;

            case "HelenOfTroyCF":
                itemValue = 4;
                break;

            case "Axe":
                itemValue = 5;
                break;

            case "FirstCampfire":
                itemValue = 6;
                break;

            case "DinoBone":
                itemValue = 7;
                break;

            case "KingTuTut":
                itemValue = 8;
                break;

            case "AmberSquito":
                itemValue = 9;
                break;

            case "Trilobite":
                itemValue = 10;
                break;

            case "WoodenTeeth":
                itemValue = 11;
                break;

            case "NapkinBonaPart":
                itemValue = 12;
                break;

            case "FirstHuman":
                itemValue = 13;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
