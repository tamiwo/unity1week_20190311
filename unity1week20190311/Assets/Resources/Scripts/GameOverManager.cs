using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    //定義
    private bool isGameOver = false;
    public GameObject ScoreManager;
    private ScoreManager manager;
    public AudioClip sound01;


    // Start is called before the first frame update
    void Start()
    {
        manager = ScoreManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        if (isGameOver == true)
        {
            return;
        }
        isGameOver = true;
        sound01.PlayOneShot(sound01.clip);
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking(manager.score);
    }
}
