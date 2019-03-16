using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayserMaganger : MonoBehaviour
{
    float yPos;

    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
#if false //できなかった時の最終的手段、A:左、S:真ん中、D:右
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(-378, y);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(0, y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(392, y);
        }
#endif


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scroll") // ハシゴ
        {
            var ladder = collision.GetComponent<Ladder>();
            // ハシゴの始点と終点を取得する
            var start = ladder.GetStartPos();// + new Vector2(0,-50);
            var end = ladder.GetEndPos();// + new Vector2(0, -50);
            Debug.Log("s,e=" + start + "," + end);

            // starとend 近いほうの点のy座標を求める
            var near = GetNearPoint(start, end);
            yPos = near.y;

            // プレイヤーのy座標の直線との交点を求める
            var cross = GetCrossPoint(start, end, new Vector2(-800,yPos), new Vector2(800, yPos));
            Debug.Log("cross(" + yPos + "):" + cross);

            // 交点をプレイヤーの座標とする
            float max;
            float min;
            //行き過ぎないように
            if (start.x > end.x) //startの方が右
            {
                max = start.x -5;
                min = end.x + 5;
            }
            else
            {
                max = end.x - 5;
                min = start.x + 5;
            }

            Debug.Log(max + "<-max,min->" + min);
            if (cross.x > max)
            {
                cross.x = max;
            }
            else if (cross.x < min)
            {
                cross.x = min;
            }

            transform.position = new Vector2(cross.x, transform.position.y);

            // ハシゴの回転角を取得する

            // プレイヤーの回転角をハシゴに合わせる

            // 回転角から背景の移動速度を変更する


        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("collisioning" + collision.tag);
        if (collision.tag == "Scroll") // ハシゴ
        {
            var ladder = collision.GetComponent<Ladder>();
            // ハシゴの始点と終点を取得する
            var start = ladder.GetStartPos();// + new Vector2(0,-50);
            var end = ladder.GetEndPos();// + new Vector2(0, -50);
            //Debug.Log("s,e=" + start + "," + end);

            // プレイヤーのy座標の直線との交点を求める
            var cross = GetCrossPoint(start, end, new Vector2(-800, yPos), new Vector2(800, yPos));
            Debug.Log("cross(" + yPos + "):" + cross);
            // 交点をプレイヤーの座標とする

            float max;
            float min;
            //行き過ぎないように
            if (start.x > end.x) //startの方が右
            {
                max = start.x;
                min = end.x;
            }
            else {
                max = end.x;
                min = start.x;
            }

            Debug.Log(max + "<-max,min->" + min);
            if (cross.x > max)
            {
                cross.x = max;
            }
            else if (cross.x < min)
            {
                cross.x = min;
            }

            transform.position = new Vector2(cross.x, transform.position.y);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("ext" + collision.tag);

    }

    Vector2 GetNearPoint(Vector2 p1, Vector2 p2)
    {
        Vector2 near;
        // starとend 近いほうの点のy座標を求める
        Vector2 p = transform.position;
        if ((p - p1).SqrMagnitude() < (p - p2).SqrMagnitude())
        {
            near = p1;
        }
        else
        {
            near = p2;
        }

        return near;
    }

    // ２つの直線の交点を求める
    private Vector2 GetCrossPoint(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
    {

        Vector2 p = Vector2.zero;
        var d = (p2.x - p1.x) * (p4.y - p3.y) - (p2.y - p1.y) * (p4.x - p3.x);

        var u = ((p3.x - p1.x) * (p4.y - p3.y) - (p3.y - p1.y) * (p4.x - p3.x)) / d;
        var v = ((p3.x - p1.x) * (p2.y - p1.y) - (p3.y - p1.y) * (p2.x - p1.x)) / d;

        p.x = p1.x + u * (p2.x - p1.x);
        p.y = p1.y + u * (p2.y - p1.y);

        return p;
    }
}
