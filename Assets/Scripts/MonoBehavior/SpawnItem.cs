using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{   
    public enum ItemType{bullet, player};
    public List<ItemData> ItemDatas = new List<ItemData>();
    public GameObject itemprefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnItemObject();
    }

    public void SpawnItemObject()
    {
        for(int i=0; i<ItemDatas.Count; i++){
            var item = SpawnItemFunc((ItemType)i);
            item.WatchMonsterInfo();
        }
    }

    public Item SpawnItemFunc(ItemType type)
    {
        var newItem = Instantiate(itemprefab).GetComponent<Item>();
        newItem.ItemData = ItemDatas[(int)(type)];
        return newItem;
    }
}
