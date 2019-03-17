using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneManger : MonoBehaviour
{

    private string scoreKey = "score";

    // Start is called before the first frame update
    void Start()
    {
        var score = PlayerPrefs.GetInt(scoreKey, 0);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }
}
