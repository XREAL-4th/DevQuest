using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public static SpawnItem main;
    public enum ItemType {speedUp, speedDown, bulletPlus};
    public List<ItemData> ItemDatas = new List<ItemData>();
    [HideInInspector] public GameObject itemPrefab; //Item 프리팹 가져오기

    private void Awake()
    {
        //질문 : 위의 public static SpawnItem main;과 Awake 함수 안 main = this 를 선언할 경우 싱글톤이 되는 것인가요?
        main = this;
        //질문 : HideInInspector로 프리팹을 불러오기 위해 Resources.Load 를 사용했습니다. 해당 방법이 올바른 방법일까요? 아니면 이외의 방법이 있을까요?
        itemPrefab = Resources.Load<GameObject>("Item");
    }

    private void Start()
    {
        SpawnItemObject();
    }

    public void SpawnItemObject()
    {
        for (int set = 0; set < 5; set++)
        {
            for (int i = 0; i < ItemDatas.Count; i++)
            {
                var item = SpawnItemFunc((ItemType)i);
                item.WatchItemInfo();
            }
        }
    }

    //질문 : SO에 저장된 아이템의 정보 중 배치 빈도 항목은 인스턴스 생성 전에 사용해야 할 것 같은데 어떻게 작성하면 좋을 지 궁금합니다.
    public Item SpawnItemFunc(ItemType type)
    {
        //지정된 범위 내 랜덤 위치 아이템 생성
        float x = Random.Range(-14, 14);
        float y = 0.6f;
        float z = Random.Range(-14, 14);
        Vector3 pos = new Vector3(x, y, z);

        var newItem = Instantiate(itemPrefab, pos, Quaternion.identity).GetComponent<Item>();
        newItem.ItemData = ItemDatas[(int)(type)];

        return newItem;
    }

}
