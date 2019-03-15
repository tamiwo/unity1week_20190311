using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMaker : MonoBehaviour
{
    public GameObject ladderPrefab;
    public GameObject parent;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
#if false // 単体で使う場合に有効にする
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
        }
#endif
    }

    public GameObject MakeLadder(Vector3 start, Vector3 end)
    {
        GameObject ladder = Instantiate(ladderPrefab, parent.transform);
        var spriteObj = ladder.transform.Find("LadderSprite");
        var sprite = spriteObj.GetComponent<SpriteRenderer>();
        Vector2 v = end - start;

        var t = ladder.transform;
        // 位置
        Vector2 pos = (end - start) / 2 + start;
        t.position = new Vector3(pos.x, pos.y, t.position.z);

        // 回転
        var rotate = -Vector2.Angle(Vector2.up, v);
        Debug.Log("rotate:" + rotate);
        t.Rotate(new Vector3(0, 0, rotate));
        // 長さ
        var length = v.magnitude / spriteObj.localScale.y;
        Debug.Log("make ladder length:" + length);
        sprite.size = new Vector2(sprite.size.x, length);

        return ladder;
    }
}
