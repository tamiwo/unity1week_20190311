using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderManager : MonoBehaviour
{
    public GameObject Ladder;
    public GameObject background;
    public int ladderMax;

    Vector3 startPos;
    List<GameObject> ladderList;
    LadderMaker ladderMaker;
    DragLineMaker lineMaker;

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

            //Debug.Log("LeftClickDown:" + startPos);
            lineMaker.StartDrag(startPos);
        }

        // ドラッグ終わり
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 3本のライン上にxの値を制限する

            //Debug.Log("LeftClickUp:" + mousePos);
            var ladder = ladderMaker.MakeLadder(startPos, mousePos);
            AddLadder(ladder);
            lineMaker.EndDrag();
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
