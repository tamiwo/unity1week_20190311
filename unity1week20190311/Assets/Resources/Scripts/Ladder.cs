using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ladder : MonoBehaviour
{
    public GameObject startPos;
    public GameObject endPos;
    Transform _start;
    Transform _end;

    private void Awake()
    {
        _start = startPos.GetComponent<Transform>();
        _end = endPos.GetComponent<Transform>();
    }

    public void SetPos(Vector2 start, Vector2 end)
    {
        _start.position = (Vector3)start;
        _end.position = (Vector3)end;
        Debug.Log(start + "," + end);
    }

    public Vector2 GetStartPos()
    {

        return _start.position;
    }


    public Vector2 GetEndPos()
    {
        return _end.position;
    }

    private void Start()
    {
        StartAnimation();
    }

    public void StartAnimation()
    {
        Vector3 rotate = new Vector3(0, 0, 10f);
        Sequence seq = DOTween.Sequence()
            .Append(transform.DOPunchRotation(rotate,0.3f));
    }
}
