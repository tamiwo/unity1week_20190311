using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form : MonoBehaviour
{
    //定数定義
    private const int MAX_Gold = 3; //Gold最大数
    public int goldMax;

    //オブジェクト参照
    public GameObject goldPrefab;         // Gold
    public GameObject canvasGame;         // ゲームキャンバス
    List<GameObject> goldList;


    // Start is called before the first frame update
    void Start()
    {
        goldList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CreateGold();
    }

    public void CreateGold()
    {
        GameObject Gold = (GameObject)Instantiate(goldPrefab);
        AddGold(Gold);
        Gold.transform.SetParent(canvasGame.transform, false);
        Gold.transform.localPosition = new Vector3(
            UnityEngine.Random.Range(-300.0f, 300.0f),
            UnityEngine.Random.Range(-140.0f, -500.0f),
            0f);

    }

    void AddGold(GameObject gold)
    {
            if (goldList.Count >= goldMax)
            {
                // 先頭を削除
                var old = goldList[0];
                goldList.RemoveAt(0);
                Destroy(old);
            }
        goldList.Add(gold);
     }

}
