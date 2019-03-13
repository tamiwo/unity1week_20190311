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
            LoadGameScene();
        }
    }

    public void LoadGameScene(){
        SceneManager.LoadScene("GameScene");
    }
    public void LoadCreditScene()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
