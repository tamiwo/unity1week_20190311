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

    // Start is called before the first frame update
    void Start()
    {
        ladderList = new List<GameObject>();
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
            var ladder = MakeLadder(startPos, mousePos);
            AddLadder(ladder);
        }
    }

    GameObject MakeLadder(Vector3 start, Vector3 end)
    {
        GameObject ladder = Instantiate(Ladder,background.transform);
        var spriteObj = ladder.transform.Find("LadderSprite");
        var sprite = spriteObj.GetComponent<SpriteRenderer>();
        Vector2 v = end - start;

        var t = ladder.transform;
        // 位置
        Vector2 pos = (end - start) / 2 + start;
        t.position = new Vector3( pos.x, pos.y, t.position.z );

        // 回転
        var rotate = -Vector2.Angle(Vector2.up, v);
        Debug.Log("rotate:" + rotate);
        t.Rotate( new Vector3(0,0,rotate) );
        // 長さ
        var length = v.magnitude / spriteObj.localScale.y;
        Debug.Log("make ladder length:" + length);
        sprite.size = new Vector2( sprite.size.x, length );

        return ladder;
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
