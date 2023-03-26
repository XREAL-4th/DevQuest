using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item")]
public class ItemData : ScriptableObject
{
    //[SerializeField]
    public enum itemType 
    {  
        SpeedItem, 
        AttackItem,
    }
    public itemType ItemType; // { get { return item; } set { item = value; } }

    [SerializeField]
    private int power;
    public int Power { get { return power; } set { power = value; } }

    [SerializeField]
    private float freq;
    public float Freq { get { return freq; } set { freq = value; } }

}