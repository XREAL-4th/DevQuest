using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemScriptable/CreateItemData", order = int.MaxValue)]

public class ItemData : ScriptableObject
{
    [SerializeField]
    private string itemName;
    public string ItemName { get { return itemName; } set { itemName = value; } }

    [SerializeField]
    private string description;
    public string Des { get { return description; } set { description = value; } }

    [SerializeField]
    private float frequent;
    public float Fre { get { return frequent; } set { frequent = value; } }

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    [SerializeField]
    private Material material;
    public Material Material { get { return material; } set { material = value; } }

    [SerializeField]
    private int Special;
    public int SP { get { return Special; } set { Special = value; } }

}
