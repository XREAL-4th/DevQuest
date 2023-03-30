using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;
    
    public void PrintItemData()
    {
        Debug.Log("아이템 이름 : " + itemData.ItemName);
        Debug.Log("체력 증가" + itemData.AddhP);
        Debug.Log("공격력 증가" + itemData.Addpower);
        Debug.Log("----------------------------------");
    }
}
