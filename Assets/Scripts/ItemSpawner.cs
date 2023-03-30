using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Plushp, Pluspower }

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> itemDatas;
    [SerializeField]
    private GameObject ItemPrefab;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < itemDatas.Count; i++)
        {
            var item = SpawnItem((ItemType)i);
            item.PrintItemData();
        }
    }

    public Item SpawnItem(ItemType type)
    {
        var newItem = Instantiate(ItemPrefab).GetComponent<Item>();
        newItem.itemData = itemDatas[(int)type];
        newItem.name = newItem.itemData.ItemName;
        return newItem;

    }
}
