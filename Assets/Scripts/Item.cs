using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static ItemManager;

public class Item : MonoBehaviour
{
    [SerializeField]
    ItemData itemData;
    public ItemData ItemData { set { itemData = value; } }

    public void WatchItemInfo()
    {
        Debug.Log(itemData.Name);
    }

    public void Init()
    {
        GetComponent<MeshFilter>().mesh = itemData.Mesh;
        GetComponent<MeshRenderer>().material = itemData.Material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (itemData.Type)
            {
                case ItemManager.ItemType.Attack:
                    {
                        collision.gameObject.GetComponent<ShootControl>().damage += itemData.value;
                        Debug.Log("Get Attack Item: " + itemData.Info);
                        break;
                    }
                case ItemManager.ItemType.Health:
                    {
                        collision.gameObject.GetComponent<Player>().CurHealth += itemData.value;
                        Debug.Log("Get Health Item" + itemData.Info);
                        break;
                    }
                case ItemManager.ItemType.Speed:
                    {
                        collision.gameObject.GetComponent<MoveControl>().moveSpeed += itemData.value;
                        Debug.Log("Get Speed Item" + itemData.Info);
                        break;
                    }
            }
            GameObject effect = Instantiate(itemData.Effect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(effect, 1.0f);

            Destroy(gameObject);
        }
    }
}
