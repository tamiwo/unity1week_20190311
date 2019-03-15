using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour {

    public AudioClip audioClip;
    AudioSource audioSource;


    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            LoadGameScene();
        }
    }

    public void LoadGameScene(){
        audioSource.Play();
        FadeManager.FadeOut(1);
        //SceneManager.LoadScene("GameScene");
    }
    public void LoadCreditScene()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
