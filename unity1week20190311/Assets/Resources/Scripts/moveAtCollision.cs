using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAtCollision : MonoBehaviour
{

    public Vector2 move;
    public string colliderName; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == colliderName)
        {
            Debug.Log("collision:" + name +" "+transform.position);
            var pos = transform.position;
            if (pos.y < 0) //連続して判定が入った場合の対処
            {
                Vector2 newPos = new Vector2(pos.x + move.x, pos.y + move.y);
                transform.position = newPos;
                RemoveChildren();
            }
        }
    }

    void RemoveChildren()
    {
        var count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            var child = transform.GetChild(i);
            if ((child.tag == "Scroll") || (child.tag == "Gold") || (child.tag == "Enemy"))
            {
                Destroy(child.gameObject);
            }
        }  
    }
}
