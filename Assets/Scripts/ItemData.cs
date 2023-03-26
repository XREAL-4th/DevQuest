using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "ScriptableObject/ItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField] private string ItemName;
    public string Name { get { return ItemName; } set { ItemName = value; } }

    [SerializeField] private ItemManager.ItemType ItemType;
    public ItemManager.ItemType Type { get { return ItemType; } set { ItemType = value; } }

    [SerializeField] private string ItemInfo;
    public string Info { get { return ItemInfo; } set { ItemInfo = value; } }

    [SerializeField] private Mesh ItemMesh;
    public Mesh Mesh { get { return ItemMesh; } set { ItemMesh = value; } }

    [SerializeField] private Material ItemMaterial;
    public Material Material { get { return ItemMaterial; } set { ItemMaterial = value; } }

    [SerializeField] private int ItemValue;
    public int value { get { return ItemValue; } set { ItemValue = value; } }

    [SerializeField] private int SpawnTime;
    public int Spawn { get { return Spawn; } set { Spawn = value; } }

    [SerializeField] private GameObject VFX;
    public GameObject Effect { get { return VFX; } set { VFX = value; } }
}
