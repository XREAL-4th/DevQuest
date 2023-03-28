using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : Box
{
    [Header("Presets")]
    public GameObject itemPref;

    protected override void OnCrashed()
    {
        base.OnCrashed();
        CreateItem();
    }

    private void CreateItem()
    {
        Item item = Instantiate(itemPref).GetComponent<Item>();
        item.transform.parent = transform;
        item.transform.position = transform.position;
    }
}
