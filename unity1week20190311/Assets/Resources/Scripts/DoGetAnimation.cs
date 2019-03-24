using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoGetAnimation : MonoBehaviour
{
    Vector3 start;
    private void Start()
    {
        start = transform.localPosition;
        Sequence sequence = Animation2();
        sequence.OnComplete(() =>
        {
            Destroy(gameObject);
        });

        sequence.Play();
    }

    public Sequence Animation1()
    {
        float duration = 0.2f;
        Vector3 scale = Vector3.one * 180f;
        Sequence upMove = DOTween.Sequence()
            .OnStart(() =>
            {
                transform.localScale = Vector3.zero;
                transform.localPosition = start;
            })
            .Append(transform.DOScale(endValue: scale, duration: duration).SetEase(Ease.InQuad))
            .Join(transform.DOLocalMove(endValue: new Vector3(start.x, start.y+300f, 0f), duration: duration).SetEase(Ease.InQuad));
        //upMove.Play();

        Sequence seq = DOTween.Sequence()

            .OnStart(() =>
            {

            })
            .Append(transform.DOPunchScale(punch: scale, duration: 0.8f,vibrato: 12));
            //.Join(transform.DOLocalMove(endValue: new Vector3(0f,200f,0f),duration:1));

        seq.Join(upMove);

        return seq;
    }

    public Sequence Animation2()
    {
        float duration = 0.5f;
        Vector3 scorePos = new Vector3(-416f, 790f, -43);
        Sequence seq = DOTween.Sequence()
            .OnStart(() =>
            {
                //transform.localScale = Vector3.one * 50;
                transform.localPosition = start;
            })
            .Append(transform.DOLocalMove(endValue: scorePos, duration: duration).SetEase(Ease.InCirc))
            .Join(transform.DOScale(endValue: Vector3.one * 200, duration: duration))
            .Append(transform.DOPunchScale(punch: Vector3.one * 180, duration: 0.5f, 8))
            .Join(transform.DOPunchPosition(punch: Vector3.one,duration: 0.5f));

        return seq;
    }

}
