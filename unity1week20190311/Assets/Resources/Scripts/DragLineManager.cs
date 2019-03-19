using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLineManager : MonoBehaviour
{

    public float[] linePos;
    public float lineWidth;

    private SpriteRenderer sprite;
    private Vector3 startPos;
    private bool isDrag;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
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
                if (((p - lineWidth) < startPos.x) && ((p + lineWidth) > startPos.x))
                {
                    sprite.enabled = true;
                    startPos.x = p;
                    isDrag = true;
                    break;
                }
            }
            //Debug.Log("LeftClickDown:" + startPos);
        }

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("LeftClickUp:" + mousePos);
            // 3本のライン上にxの値を制限する
            foreach (float p in linePos)
            {
                if (((p - lineWidth) < mousePos.x) && ((p + lineWidth) > mousePos.x))
                {
                    mousePos.x = p;
                    break;
                }
            }
            DrawLine(startPos, mousePos);

        }

        // ドラッグ終わり
        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
            sprite.enabled = false;
        }
    }

    public void DrawLine(Vector3 start, Vector3 end)
    {
        Vector2 v = end - start;
        var t = transform;

        // 位置
        Vector2 pos = (end - start) / 2 + start;
        t.position = new Vector3(pos.x, pos.y, t.position.z);

        // 回転
        var angle = Vector2.Angle(Vector2.up, v);
        Vector3 cross = Vector3.Cross(Vector2.up, v);

        if (cross.z > 0)
        {
            angle = 360 - angle;
        }

        t.eulerAngles = new Vector3(0, 0, -angle);

        // 長さ
        var length = v.magnitude / t.localScale.y;
        sprite.size = new Vector2(sprite.size.x, length);

    }

}
