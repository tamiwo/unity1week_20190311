using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Collider : MonoBehaviour
{

    public GameObject ScoreManager;
    private ScoreManager manager;

    public GameObject GameOverManager;
    private GameOverManager gameover;

    public AudioClip soundGold;
    AudioSource audioSource;

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
            Debug.Log("GoldがPlayerと接触");
            manager.Add(1);
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(soundGold);

        } else if (collision.gameObject.tag == "Enemy")
        {
            gameover.GameOver();
            Debug.Log("EnemyがPlayerと接触");
        }
    }

}
