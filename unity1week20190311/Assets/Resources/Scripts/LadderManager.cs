using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderManager : MonoBehaviour
{
    public GameObject Ladder;
    public GameObject background;

    bool isDragging = false;
    Vector3 startPos;
    LineRenderer line;


    // Start is called before the first frame update
    void Start()
    {
        //line = Instantiate(LadderSprite);
        line = gameObject.GetComponent<LineRenderer>();
        // 線の幅
        line.startWidth = 50f;
        line.endWidth = 50f;
        // 頂点の数
        line.positionCount = 2;
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ドラッグ開始
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPos.z = 0f;
            Debug.Log("LeftClickDown:" + startPos);
            line.enabled = true;
            line.SetPosition(0, startPos);
            line.SetPosition(1, startPos);
            isDragging = true;
            
        }

        // ドラッグ中
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            line.SetPosition(1, mousePos);
        }

        // ドラッグ終わり
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("LeftClickUp:" + mousePos);
            isDragging = false;
            MakeLadder(startPos, mousePos);
            //line.enabled = false;
        }
    }

    void MakeLadder(Vector3 start, Vector3 end)
    {
        GameObject ladder = Instantiate(Ladder,background.transform);
        var spriteObj = ladder.transform.Find("LadderSprite");
        var sprite = spriteObj.GetComponent<SpriteRenderer>();
        var length = Vector3.Distance(end, start) / spriteObj.localScale.y;
        Debug.Log("make ladder length:" + length);
        sprite.size = new Vector2( sprite.size.x, length );
    }
}
