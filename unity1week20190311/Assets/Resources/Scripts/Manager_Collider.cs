using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Collider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            Destroy(this.gameObject);
            Debug.Log("OnTriggerEnter2Dが発動");
        }
    }

}
