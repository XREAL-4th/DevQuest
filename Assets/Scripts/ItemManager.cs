using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> ItemPrefabs = new List<GameObject>();
    public GameObject[] Items;

    void Start()
    {
        Items = new GameObject[ItemPrefabs.Count];

        for (int i = 0; i < ItemPrefabs.Count; i++)
        {
            Items[i] = Instantiate(ItemPrefabs[i]);
            StartCoroutine(Spawn(Items[i], Items[i].GetComponent<Item>().Freq));
        }
    }

    public IEnumerator Spawn(GameObject obj, float freq)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(freq);

        if (obj != null)
        {
            StartCoroutine(Spawn(obj, freq));
        }
        
    }

}