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

    // Start is called before the first frame update
    void Start()
    {
        ladderList = new List<GameObject>();
        ladderMaker = GetComponent<LadderMaker>();
    }

    // Update is called once per frame
    void Update()
    {
        // ドラッグ開始
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPos.z = 0f;
            //Debug.Log("LeftClickDown:" + startPos);
        }

        // ドラッグ終わり
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("LeftClickUp:" + mousePos);
            var ladder = ladderMaker.MakeLadder(startPos, mousePos);
            AddLadder(ladder);
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
