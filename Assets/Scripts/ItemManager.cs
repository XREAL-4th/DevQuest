using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance = null;
    public List<GameObject> ItemPrefabs = new List<GameObject>();

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
        for (int i = 0; i < ItemPrefabs.Count; i++)
        {
            GameObject item = Instantiate(ItemPrefabs[i]);
        }
    }

}

