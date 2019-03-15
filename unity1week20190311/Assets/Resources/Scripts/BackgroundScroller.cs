using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    public Vector2 speed;
    public GameObject[] backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(backgrounds[0].transform.position);

        SetVelocity(speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetVelocity(Vector2 velocity)
    {
        for (int i = 0; i < 3; i++)
        {
            var r = backgrounds[i].GetComponent<Rigidbody2D>();
            r.velocity = velocity;
        }
    }
}
