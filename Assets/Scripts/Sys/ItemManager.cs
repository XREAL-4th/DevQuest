using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance = null;
    public GameObject itemPrefab;
    public ItemData[] itemList;
    ScriptableObject t;
    public Transform[] itemSpawnPoint;

    //non-lazy, non-DDOL
    private void Awake()
    {
        instance = this;
        itemSpawnPoint = GameObject.FindGameObjectWithTag("ItemSpawnPoint").GetComponentsInChildren<Transform>();
        for(int i = 1; i < itemSpawnPoint.Length; i++)
        {
            GameObject tmp;
            tmp = Instantiate(itemPrefab);
            tmp.transform.position = itemSpawnPoint[i].position;
            int ran = Random.Range(0, itemList.Length);
            tmp.GetComponent<ItemFunctions>().itemData = itemList[ran];
        }
    }

}
