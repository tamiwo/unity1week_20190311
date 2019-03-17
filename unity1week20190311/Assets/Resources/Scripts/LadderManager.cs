using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderManager : MonoBehaviour
{
    public GameObject Ladder;
    public GameObject background;
    public int ladderMax;
    public float[] linePos;
    public float lineWidth;

    Vector3 startPos;
    List<GameObject> ladderList;
    LadderMaker ladderMaker;
    DragLineMaker lineMaker;
    bool isDraw = false;

    // Start is called before the first frame update
    void Start()
    {
        ladderList = new List<GameObject>();
        ladderMaker = GetComponent<LadderMaker>();
        lineMaker = GetComponent<DragLineMaker>();
    }

    // Update is called once per frame
    void Update()
    {
        // ドラッグ開始
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPos.z = 0f;
            // 3本のライン上にxの値を制限する
            foreach (float p in linePos) 
            {
                if ( ( (p - lineWidth) < startPos.x ) && ( (p + lineWidth) > startPos.x ) ) 
                {
                    startPos.x = p;
                    isDraw = true;
                    break;
                }
            }
            if (isDraw)
            {
                lineMaker.StartDrag(startPos);
            }
        }

        if (isDraw)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            // 3本のライン上にxの値を制限する
            foreach (float p in linePos)
            {
                if (((p - lineWidth) < mousePos.x) && ((p + lineWidth) > mousePos.x))
                {
                    mousePos.x = p;
                    break;
                }
            }
            lineMaker.Dragging(mousePos);
        }

        // ドラッグ終わり
        if (Input.GetMouseButtonUp(0) && isDraw)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 3本のライン上にxの値を制限する
            bool isOnLine = false;
            foreach (float p in linePos)
            {
                if (((p - lineWidth) < mousePos.x) && ((p + lineWidth) > mousePos.x))
                {
                    mousePos.x = p;
                    isOnLine = true;
                    break;
                }
            }
            if (isDraw)
            {
                lineMaker.EndDrag();
                if (isOnLine)
                {

                    if (startPos.y + 1 > mousePos.y && mousePos.y > startPos.y - 1)
                    {
                        if (startPos.y > mousePos.y)
                        {
                            startPos.y += 1;
                        }
                        else
                        {
                            mousePos.y += 1;
                        }
                    }

                    if (startPos.x + 1 > mousePos.x && mousePos.x > startPos.x - 1)
                    {

                    }
                    else
                    {
                        var ladder = ladderMaker.MakeLadder(startPos, mousePos);
                        AddLadder(ladder);
                    }
                }
            }
            isDraw = false;
        }
    }

    void AddLadder(GameObject ladder)
    {
        Debug.Log("ladders:" + ladderList.Count);
        if( ladderList.Count >= ladderMax)
        {
            // 先頭を削除
            var old = ladderList[0];
            ladderList.RemoveAt(0);
            Destroy(old);
        }
        ladderList.Add(ladder);
    }
}
