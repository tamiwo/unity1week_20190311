using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLineMaker : MonoBehaviour
{
    bool isDragging = false;
    Vector3 startPos;
    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
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

#if false //単体で使う場合に有効にする
        // ドラッグ開始
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartDrag(mousePos);
        }
        
        // ドラッグ中
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Dragging(mousePos);
        }

        // ドラッグ終わり
        if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
#endif
    }

    public void StartDrag( Vector3 pos )
    {
        startPos = pos;
        startPos.z = 0f;
        //Debug.Log("LeftClickDown:" + startPos);
        line.enabled = true;
        line.SetPosition(0, startPos);
        line.SetPosition(1, startPos);
        isDragging = true;
    }

    public void Dragging( Vector3 pos )
    {
        pos.z = 0f;
        line.SetPosition(1, pos);
    }

    public void EndDrag()
    {
        //Debug.Log("LeftClickUp:" + mousePos);
        isDragging = false;
        line.enabled = false;
    }
}
