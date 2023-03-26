using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance = null;
    public List<GameObject> ItemPrefabs = new List<GameObject>();
    public GameObject[] Items;

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


        Items = new GameObject[ItemPrefabs.Count];
        for(int i=0; i< ItemPrefabs.Count; i++)
        {
            Items[i] = Instantiate(ItemPrefabs[i]);
            StartCoroutine(Spawn(Items[i], 10.0f));
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

  

    IEnumerator Spawn(GameObject obj, float freq)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(freq);

        StartCoroutine(Spawn(obj, freq));
    }

}