using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string itemName;
    public string ItemName { get { return itemName;  } }
    [SerializeField]
    private int addhp;
    public int AddhP { get { return addhp; } }
    [SerializeField]
    private int addpower;
    public int Addpower { get { return addpower; } }
    [SerializeField]
    private GameObject ItemAssets;

}
