using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGoldCollider : MonoBehaviour
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
        // enemyと同じ位置に生成されて場合は消す
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Debug.Log("Enamy exsit");
        }
    }
}
