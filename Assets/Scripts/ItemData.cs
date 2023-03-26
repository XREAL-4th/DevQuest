using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemData", menuName ="ItemScriptable/ItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string itemName;
    public string ItemName {  get { return itemName; } set { itemName = value; } }

    [SerializeField]
    private int affect;
    public int Affect { get { return affect; } set { affect = value; } }
}
