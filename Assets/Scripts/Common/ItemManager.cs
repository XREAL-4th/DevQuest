using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    public enum ItemType
    {
        Attack,
        Health,
        Speed
    }

    public List<ItemData> ItemDatas = new List<ItemData>();
    public GameObject ItemPrefab;
    public Transform[] ItemPoints; // Enemy Location
    public int maxItem = 3;

    public static ItemManager instance = null;

    public static ItemManager Instance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void Init()
    {
        ItemPoints = GameObject.Find("ItemSpawnPointGroup").GetComponentsInChildren<Transform>();

        if (ItemPoints.Length > 0)
        {
            StartCoroutine(this.CreateItem());
        }
    }

    IEnumerator CreateItem()
    {
        while (GameManager.instance.isGameOver == false)
        {
            int itemCount = (int)GameObject.FindGameObjectsWithTag("ITEM").Length;

            if (itemCount < maxItem)
            {
                yield return new WaitForSeconds(5);

                int pointIdx = UnityEngine.Random.Range(1, ItemPoints.Length);
                int itemIdx = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(ItemType)).Length);

                var newItem = Instantiate(ItemPrefab, ItemPoints[pointIdx].position+new Vector3(0, 1.5f, 0), ItemPoints[pointIdx].rotation, GameObject.Find("Items").transform).GetComponent<Item>();
                newItem.ItemData = ItemDatas[(int)itemIdx];

                // Set Item Mesh, Material 
                newItem.Init();
                //newItem.WatchItemInfo();
            }
            else yield return null;
        }
    }
}
