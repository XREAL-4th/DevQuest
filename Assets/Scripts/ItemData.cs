using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemScriptable/CreateItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private float power;
    public float Power { get { return power; } set { power = value; } }

    [SerializeField]
    private string itemName;
    public string Name { get { return itemName; } set { itemName = value; } }

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    [SerializeField]
    private float score;
    public float Score { get { return score; } set { score = value; } }

    [SerializeField]
    private float health;
    public float Health { get { return health; } set { health = value; } }
}

