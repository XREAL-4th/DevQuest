using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public enum ItemType { SpeedUp, JumpUp};
    public List<ItemData> ItemDatas = new List<ItemData>();

    public GameObject itemPrefab;

    private void Start()
    {
        SpawnItemObject();
    }

    public void SpawnItemObject()
    {
        for (int i = 0; i < ItemDatas.Count; i++)
        {
            var item = SpawnItemFunc((ItemType)i);
            item.WatchItemInfo();
        }
    }

    public Item SpawnItemFunc(ItemType type)
    {
        var newItem = Instantiate(itemPrefab).GetComponent<Item>();
        newItem.ItemData = ItemDatas[(int)(type)];
        return newItem;
    }
}
