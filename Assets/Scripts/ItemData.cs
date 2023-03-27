using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable/ItemData")]

public class ItemData : ScriptableObject
{
    private string name;
    public int damage;
    public int speed;
    public GameObject itemPrefab;
}
