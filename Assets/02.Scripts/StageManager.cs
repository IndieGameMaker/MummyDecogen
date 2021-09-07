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

        // GoodItem 생성
        MakeItem(goodList, goodItem, goodItemCount);

        // BadItem 생성
        MakeItem(badList, badItem, badItemCount);
    }

    void MakeItem(List<GameObject> itemList, GameObject item, int count)
    {
        for (int i = 0; i < count; i++)
        {
            // 불규칙한 위치좌표와 회전값을 생성
            Vector3 pos = new Vector3(Random.Range(-22.0f, 22.0f), 0.05f, Random.Range(-22.0f, 22.0f));
            Quaternion rot = Quaternion.Euler(Vector3.up * Random.Range(0, 360));

            itemList.Add(Instantiate(item, transform.position + pos, rot, transform));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitStage();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
