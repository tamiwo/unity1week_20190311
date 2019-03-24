using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Manager_Collider : MonoBehaviour
{

    public GameObject ScoreManager;
    private ScoreManager manager;

    public GameObject GameOverManager;
    private GameOverManager gameover;

    public AudioClip soundGold;
    AudioSource audioSource;

    public GameObject tweenGold;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        manager = ScoreManager.GetComponent<ScoreManager>();
        gameover = GameOverManager.GetComponent<GameOverManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Gold") 
        {
            AddGoldPoint();
            Instantiate(tweenGold, transform.parent)
                .transform.position = transform.position;

        } else if (collision.gameObject.tag == "Enemy")
        {
            gameover.GameOver();
            Debug.Log("EnemyがPlayerと接触");
        }
    }

    void AddGoldPoint()
    {
        manager.Add(1);
        audioSource.PlayOneShot(soundGold);
        Debug.Log("GoldがPlayerへ接触");
    }

    public void TouchGold()
    {
        RectTransform rect = GetComponent<RectTransform>();
        //オーブの軌跡設定
        Vector3[] path =
        {
            new Vector3(rect.localPosition.x * 1.5f, 300f, 0f), //中間点
            new Vector3(0f, 150f, 0f),

        };

        //アニメ作成
        rect.DOLocalPath(path, 0.5f, PathType.CatmullRom)
            .SetEase(Ease.OutQuad)
            .OnComplete(AddGoldPoint);
        //サイズ変更
        rect.DOScale(
            new Vector3(0.5f, 0.5f, 0f),
            0.5f
            );
    }

}
