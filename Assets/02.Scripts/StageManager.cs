using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject goodItem;
    public GameObject badItem;

    [Range(10, 50)]
    public int goodItemCount = 30;
    [Range(10, 50)]
    public int badItemCount = 20;

    public List<GameObject> goodList = new List<GameObject>();
    public List<GameObject> badList = new List<GameObject>();

    public void InitStage()
    {
        // 기존에 생성된 모든 아이템을 삭제 및 List 초기화
        foreach (var obj in goodList)
        {
            Destroy(obj);
        }
        foreach (var obj in badList)
        {
            Destroy(obj);
        }

        goodList.Clear();
        badList.Clear();


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
