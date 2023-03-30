using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]

public class ItemData : ScriptableObject
{
    [SerializeField]
    private string itemName;
    public string Name {get {return itemName;} set {itemName = value;}}
    [SerializeField]
    private float speed;
    public float Speed {get {return speed;} set{speed = value;}}

}
