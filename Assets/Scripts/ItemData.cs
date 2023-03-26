using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 에디터에서 쉽게 사용할 수 있도록 메뉴를 만듬
[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object Asset/ItemData")]
public class ItemData : ScriptableObject
{
    public string ItemName; //아이템 이름
    public int affectAttack = 5; //아이템 먹으면 공격력에 얼만큼 영향을 주는지
    public GameObject effect; //VFX

}