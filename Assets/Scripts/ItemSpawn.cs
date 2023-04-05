using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{

    public enum ItemType {  Basic, Double };
    public List<ItemData> ItemDatas = new List<ItemData>();

    public GameObject itemPrefab;


    public GameObject rangeObject;
    BoxCollider rangeCollider;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

    // RespawnRange의 포지션 값인 Vector3 변수를 만들, 콜라이더의 사이즈를 이용해 콜라디어 범위
    // 내에서 랜덤한 위치를 가진 벡터값을 구한 후 서로의 백터값을 더하,
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;

        // 콜라이더의 사이즈 가져오는 bounf.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;      
        return respawnPosition;
    }

    void Start()
    {
        SpawnItemObject(5);
    }

    public void SpawnItemObject(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int random = Random.Range(0, 2);
            var item = ItemSpawnFunc((ItemType)random);
            item.WatchItemInfo();
        }
    }

    public Item ItemSpawnFunc(ItemType type)
    {
        var newItem = Instantiate(itemPrefab, Return_RandomPosition(), Quaternion.identity ).GetComponent<Item>();
        newItem.ItemData = ItemDatas[(int)(type)];
        return newItem;
    }
}
