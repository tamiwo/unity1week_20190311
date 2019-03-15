using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision tag: " + collision.tag );

        if ((collision.tag == "Scroll") || (collision.tag == "Gold") || (collision.tag == "Enemy"))
        {
            var tf = collision.gameObject.transform;
            tf.SetParent(this.transform);
        }
    }
}
