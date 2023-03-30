using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public enum ItemType {  Basic, Double };
    public List<ItemData> ItemDatas = new List<ItemData>();

    public GameObject itemPrefab;

    void Start()
    {
        SpawnItemObject(10);
    }

    public void SpawnItemObject(int count)
    {
        for (int i = 0; i < count; i++)
        {
            //int random = Random.Range(0, 9);
            var item = ItemSpawnFunc((ItemType)i);
            item.WatchItemInfo();
        }
    }

    public Item ItemSpawnFunc(ItemType type)
    {
        var newItem = Instantiate(itemPrefab).GetComponent<Item>();
        newItem.ItemData = ItemDatas[(int)(type)];
        return newItem;
    }
}
