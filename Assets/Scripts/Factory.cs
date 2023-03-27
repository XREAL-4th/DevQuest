using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEM
{
    SpeedUp,
    JumpUp
}
public class Factory : ItemFactory<ITEM>
{
    [SerializeField]
    private GameObject SpeedUpPrefab = null;
    [SerializeField]
    private GameObject JumpUpPrefab = null;

    protected override Item Create(ITEM _type)
    {
        Item item = null;
        switch (_type)
        {
            case ITEM.SpeedUp:
                item = Instantiate(this.SpeedUpPrefab).GetComponent<Item>();
                break;
            case ITEM.JumpUp:
                item = Instantiate(this.JumpUpPrefab).GetComponent<Item>();
                break;
        }
        return item;
    }
}
