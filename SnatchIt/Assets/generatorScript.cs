using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorScript : MonoBehaviour
{
    public string grabInput;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetButtonDown(grabInput) && collision.gameObject.tag == ("Generator"))
        {
            laser.SetActive(false);
            //source3.Play();
          
        }
    }
}
