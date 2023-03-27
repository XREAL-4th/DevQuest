using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemScriptable/CreateItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string itemName;
    public string Name { get { return itemName; } set { itemName = value; } }

    [SerializeField]
    private string effect;
    public string Effect { get { return effect; } set { effect = value; } }
}
