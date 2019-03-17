using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MonoBehaviour
{

    public void LoadGameScene()
    {
        FadeManager.FadeOut(1);
        //SceneManager.LoadScene("GameScene");
    }
}
