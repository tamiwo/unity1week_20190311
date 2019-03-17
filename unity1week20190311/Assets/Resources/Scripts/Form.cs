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
    public GameObject backgroundScrollerObj;
    private BackgroundScroller bgScroller;

    //生成確率
    public float create1Position;
    public float create2Position;

    // Start is called before the first frame update
    void Start()
    {
        List = new List<GameObject>();
        SetTimer();
        bgScroller = backgroundScrollerObj.GetComponent<BackgroundScroller>();

    }

    // Update is called once per frame
    void Update()
    {
        // 背景のスピードが上がるほど早く時間を進めて早く生成する
        float timeScale = bgScroller.speed.y / bgScroller.initialSpeed.y;
        time += Time.deltaTime * timeScale;
        if(time > interval)
        {
            Create();
            SetTimer(0);
        }
    }

    public void Create()
    {
        //ランダムで1箇所 or 2箇所に生成
        float pos = Random.value; //0 〜 1
        if (pos < create1Position) //
        {
            CreateCenter();
        }
        else if (pos < create1Position * 2)
        {
            CreateLeft();
        }
        else if (pos < create1Position * 3)
        {
            CreateRight();
        }
        else if (pos < (create2Position + create1Position * 3))
        {
            CreateRight();
            CreateCenter();
        }
        else if (pos < (create2Position * 2 + create1Position * 3))
        {
            CreateCenter();
            CreateLeft();
        }
        else if (pos < (create2Position * 3 + create1Position * 3))
        {
            CreateLeft();
            CreateRight();
        }
        else
        {
        }
    }

    public void CreateCenter()
    {
        GameObject prefab = (GameObject)Instantiate(Prefab);
        //Add(prefab);
        prefab.transform.SetParent(canvasGame.transform, false);
        prefab.transform.localPosition = new Vector3(
            0.0f,
            //UnityEngine.Random.Range(-300.0f, 300.0f),
            //UnityEngine.Random.Range(1400.0f, 3000.0f),
            1500f,
            0f);
    }

    public void CreateLeft()
    {
        GameObject prefab = (GameObject)Instantiate(Prefab);
        //Add(prefab);
        prefab.transform.SetParent(canvasGame.transform, false);
        prefab.transform.localPosition = new Vector3(
            -378.0f,
            //UnityEngine.Random.Range(-300.0f, 300.0f),
            //UnityEngine.Random.Range(1400.0f, 3000.0f),
            1500f,
            0f);
    }

    public void CreateRight()
    {
        GameObject prefab = (GameObject)Instantiate(Prefab);
        //Add(prefab);
        prefab.transform.SetParent(canvasGame.transform, false);
        prefab.transform.localPosition = new Vector3(
            392.0f,
            //UnityEngine.Random.Range(-300.0f, 300.0f),
            //UnityEngine.Random.Range(1400.0f, 3000.0f),
            1500f,
            0f);
    }


    void Add(GameObject prefab)
    {
        if (List.Count >= Max)
        {
            // 先頭を削除
            var old = List[0];
            List.RemoveAt(0);
            Debug.Log(old.name + " count Over" + List.Count);
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
