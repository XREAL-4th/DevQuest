using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnItem : MonoBehaviour
{
    public static SpawnItem main;
    public enum ItemType { SpeedUp, PowerUp, ScoreUp };
    public List<ItemData> ItemDatas = new List<ItemData>();

    public List<GameObject> ItemPrefabs = new List<GameObject>();

    private void Start()
    {
        main = this;
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
        var newItem = Instantiate(ItemPrefabs[(int)(type)]).GetComponent<Item>();
        newItem.ItemData = ItemDatas[(int)(type)];
        return newItem;
    }
}
