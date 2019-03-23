using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            // タッチ/マウス入力のときは呼ばない
            if ((Input.touchCount <= 0) &&
                 (!Input.GetMouseButton(0)) &&
                 (!Input.GetMouseButton(1)) &&
                 (!Input.GetMouseButton(2)))
            {
                LoadGameScene();
            }
        }
    }

    public void LoadGameScene(){
        FadeManager.FadeOut(1);
        //SceneManager.LoadScene("GameScene");
    }
    public void LoadCreditScene()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
