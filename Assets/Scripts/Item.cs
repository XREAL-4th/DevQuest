using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;
    
    public void PrintItemData()
    {
        Debug.Log("������ �̸� : " + itemData.ItemName);
        Debug.Log("ü�� ����" + itemData.AddhP);
        Debug.Log("���ݷ� ����" + itemData.Addpower);
        Debug.Log("----------------------------------");
    }
}
