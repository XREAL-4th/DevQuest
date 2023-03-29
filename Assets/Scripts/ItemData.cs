using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemScriptable/CreateItemData")]
public class ItemData: ScriptableObject
{
    public enum ItemType{
        TimeBonus,
        SpeedUp
    }

    public string itemName;
    public ItemType itemType;
    public GameObject itemPrefab;

    // [SerializeField]
    // private float time;
    // public float time { get { return time; } set { time = value; } }

	// [SerializeField]
    // private float hp;
    // public float HP { get { return hp; } set { hp = value; } }

    // [SerializeField]
    // private float speed;
    // public float Speed { get { return speed; } set{ speed = value; } }
}