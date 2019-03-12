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
            Debug.Log("collision:" + colliderName);
            var pos = transform.position;
            Vector2 newPos = new Vector2(pos.x + move.x, pos.y + move.y);
            transform.position = newPos;
        }
    }
}
