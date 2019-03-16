using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form : MonoBehaviour
{
    //定数定義
    private const int MAX = 3; //Gold最大数
    public int Max;
    public float minInterval;
    public float maxInterval;
    private float interval;
    private float time;

    //オブジェクト参照
    public GameObject Prefab;     
    public GameObject canvasGame;         // ゲームキャンバス
    List<GameObject> List;


    // Start is called before the first frame update
    void Start()
    {
        List = new List<GameObject>();
        SetTimer();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > interval)
        {
            Create();
        }
    }

    public void Create()
    {
        CreateCenter();
        CreateLeft();
        CreateRight();
    }

    public void CreateCenter()
    {
        GameObject prefab = (GameObject)Instantiate(Prefab);
        Add(prefab);
        prefab.transform.SetParent(canvasGame.transform, false);
        prefab.transform.localPosition = new Vector3(
            0.0f,
            //UnityEngine.Random.Range(-300.0f, 300.0f),
            UnityEngine.Random.Range(1400.0f, 3000.0f),
            0f);
        SetTimer(0);
    }

    public void CreateLeft()
    {
        GameObject prefab = (GameObject)Instantiate(Prefab);
        Add(prefab);
        prefab.transform.SetParent(canvasGame.transform, false);
        prefab.transform.localPosition = new Vector3(
            -378.0f,
            
            //UnityEngine.Random.Range(-300.0f, 300.0f),
            UnityEngine.Random.Range(1400.0f, 3000.0f),
            0f);
        SetTimer(0);
    }

    public void CreateRight()
    {
        GameObject prefab = (GameObject)Instantiate(Prefab);
        Add(prefab);
        prefab.transform.SetParent(canvasGame.transform, false);
        prefab.transform.localPosition = new Vector3(
            392.0f,
            
            //UnityEngine.Random.Range(-300.0f, 300.0f),
            UnityEngine.Random.Range(1400.0f, 3000.0f),
            0f);
        SetTimer(0);
    }


    void Add(GameObject prefab)
    {
            if (List.Count >= Max)
            {
                // 先頭を削除
                var old = List[0];
                List.RemoveAt(0);
                Destroy(old);
            }
        List.Add(prefab);
     }

    void SetTimer(int val = 0)
    {
        if(val == 0)
        {
            interval = Random.Range(minInterval, maxInterval);
        }
        else
        {
            interval = (float)val;
        }
        time = 0;
    }
}
