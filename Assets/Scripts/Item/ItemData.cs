using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemScriptable/ItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    public int itemCode;
    public string itemName;
    public string itemDescription;
    public ParticleSystem itemFx;
}
