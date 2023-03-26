using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance = null;
    public List<GameObject> ItemPrefabs = new List<GameObject>();
    private float timer;

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
        timer = 0;
        SpawnItemObject();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 12f)
        {
            SpawnItemObject();
            timer = 0f;
        }
    }

    public void SpawnItemObject()
    {
        for (int i = 0; i < ItemPrefabs.Count; i++)
        {
            GameObject item = Instantiate(ItemPrefabs[i]);

            //Debug.Log(item.GetComponent<ItemData>().Power);

            Destroy(item, 5f);

        }
    }

}