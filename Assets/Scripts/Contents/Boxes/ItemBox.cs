using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ItemBox : Box
{
    public GameObject itemPref;

    protected override void OnCrashed()
    {
        base.OnCrashed();
        CreateItem();
    }

    private void CreateItem()
    {
        Item item = ContentFactory.Main.CreateItem(itemPref);
        item.transform.parent.parent = transform;
        item.transform.position = transform.position;
    }
}
