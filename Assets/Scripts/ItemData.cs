using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Item들의 데이터를 관리할 수 있는 스크립트
// 이름, 효과
[CreateAssetMenu(fileName = "ItemData", menuName ="ItemScriptable/ItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string itemName;
    public string ItemName {  get { return itemName; } set { itemName = value; } }

    [SerializeField]
    private int affect;
    public int Affect { get { return affect; } set { affect = value; } }
}
