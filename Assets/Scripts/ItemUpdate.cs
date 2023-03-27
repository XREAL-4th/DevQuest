using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemUpdate : MonoBehaviour
{
    private static ItemManager instance = null;
    public List<GameObject> ItemPrefabs = new List<GameObject>();
    public GameObject[] Items;



    void Start()
    {
        Items = new GameObject[ItemPrefabs.Count];

        for (int i = 0; i < ItemPrefabs.Count; i++)
        {
            Items[i] = Instantiate(ItemPrefabs[i]);
            StartCoroutine(ItemManager.Instance.Spawn(Items[i], Items[i].GetComponent<Item>().Freq));
        }
    }


}