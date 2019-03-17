using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEventHandler : MonoBehaviour
{
    public string collisionDetectTag = null;

    // 衝突させた時に発生させるイベント
   [SerializeField]
    private UnityEvent collisionEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == collisionDetectTag)
        {
            collisionEvent.Invoke();
        }
    }
}
