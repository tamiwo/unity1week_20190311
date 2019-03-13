using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject backgroundPrefab;
    public Vector2 backgroundSize;
    public Vector2 speed;
    private GameObject[] backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        backgrounds = new GameObject[3];
        //3つ並べる
        backgrounds[0] = Instantiate(backgroundPrefab,transform);
        backgrounds[1] = Instantiate(backgroundPrefab,transform);
        backgrounds[2] = Instantiate(backgroundPrefab,transform);
        Vector2 pos = transform.position;
        backgrounds[0].transform.position =  backgroundSize*2;
        backgrounds[2].transform.position =  -backgroundSize*2;
       
        Debug.Log(backgrounds[0].transform.position);

        SetVelocity(speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetVelocity(Vector2 speed)
    {
        for (int i = 0; i < 3; i++)
        {
            var r = backgrounds[i].GetComponent<Rigidbody2D>();
            r.velocity = speed;
        }
    }
}
