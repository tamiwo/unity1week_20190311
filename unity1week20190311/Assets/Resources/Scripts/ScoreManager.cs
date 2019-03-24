using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public GameObject textScoreObj;
    //public GameObject textHiscoreObj;
    private Text textScore;
    //private Text textHiscore;
    public int score;
    private int hiscore;
    private string key = "Hiscore";
    private string scoreKey = "score";

    // Use this for initialization
    void Start () {
        //score = PlayerPrefs.GetInt(scoreKey, 0);
        score = 0;
        PlayerPrefs.SetInt(scoreKey, 0);
        textScore = textScoreObj.GetComponent<Text>();
        textScore.text = string.Format("{0:0}", score);
        //hiscore = PlayerPrefs.GetInt(key, 0);
        //Debug.Log("hiscoe read" + hiscore);
        //textHiscore = textHiscoreObj.GetComponent<Text>();
        //textHiscore.text = string.Format("{0:00000}", hiscore);
    }
    
    // Update is called once per frame
    void Update () {
    }

    public void Add(int num){
        score += num;
        textScore.text = string.Format("{0:0}", score);
        Debug.Log("Add発動");
        Debug.Log(score);
        Debug.Log("textScore" + textScore.text);
    }

    /*
    public void CheckHiscore(){
        if( hiscore < score ){
            hiscore = score;
            PlayerPrefs.SetInt(key, hiscore);
            Debug.Log("hiscoe up" + hiscore);
            textHiscore.text = string.Format("{0:00000}", hiscore);
        }
    }
    */

    public void SaveScore(){
        Debug.Log("saveScore" + score);
        PlayerPrefs.SetInt(scoreKey, score);
        string totalKey = "totalGold";
        int total = PlayerPrefs.GetInt(totalKey, 0);
        Debug.Log("total:" + total + "+" + score + "=" + (total + score));
        PlayerPrefs.SetInt(totalKey, total + score);
    }

}
