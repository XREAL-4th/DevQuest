using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance = null;

    public enum ItemType { SpeedItem1, SpeedItem2, AttackItem1, AttackItem2 };
    public List<ItemData> ItemDatas = new List<ItemData>();
    public List<GameObject> itemPrefabs = new List<GameObject>();

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {   
            Destroy(this.gameObject);
        }
    }

    public static ItemManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Start()
    {
        SpawnItemObject();
    }

    public void SpawnItemObject()
    {
        for (int i = 0; i < ItemDatas.Count; i++)
        {
            var item = SpawnItemFunc((ItemType)i);
            //item.WatchItemInfo();
        }
    }

    public Item SpawnItemFunc(ItemType type)
    {
        var newItem = Instantiate(itemPrefabs[(int)(type)]).GetComponent<Item>();
        newItem.ItemData = ItemDatas[(int)(type)];
        return newItem;
    }
}

