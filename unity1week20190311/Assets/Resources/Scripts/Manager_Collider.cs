using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Collider : MonoBehaviour
{

    public GameObject ScoreManager;
    private ScoreManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = ScoreManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Gold") 
        {
            Debug.Log("GoldがPlayerと接触");
            manager.Add(1);
        }
    }

}
