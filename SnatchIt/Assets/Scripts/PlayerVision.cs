using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    public GameObject owner;
    public string threatTag;
    public CharacterController script;
    public bool enemySeen = false;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == threatTag)
        {
            enemySeen = true;
            print("enemy see");
            owner.SendMessage("OnWhistleEnter", other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == threatTag)
        {
            enemySeen = false;
          
            print("enemy exit");
            owner.SendMessage("OnWhistleExit", other);
        }
    }
    //private void Update()
    //{
    //    for (int i = script.whistles.Count - 1; i >= 0; i--)
    //    {
    //        GameObject objectInVolume = script.whistles[i];

    //        // if object has been disabled or deleted, remove it from both lists
    //        if (objectInVolume == null || !objectInVolume.activeSelf)
    //        {

    //            LostSight(objectInVolume);
    //            script.whistles.Remove(objectInVolume);

    //            continue;

    //        }
    //    }
    //}
    //void LostSight(GameObject other)
    //{
    //    if (script.whistles.Contains(other))
    //    {
    //        script.whistles.Remove(other);
    //    }
    //}

}

