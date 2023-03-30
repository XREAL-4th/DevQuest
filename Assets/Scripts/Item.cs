using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    ItemData itemData;
    public ItemData ItemData { set { itemData = value; } }
    // SO사용하고 itemData변수를 수정하기 위해 set 프로퍼티 사용

    public void WatchItemInfo() // 생성된 프리팹들의 정보를 확인하기위해 만들어둔 함수
    {
        Debug.Log(itemData.ItemName);
        Debug.Log(itemData.Affect);
    }
}
