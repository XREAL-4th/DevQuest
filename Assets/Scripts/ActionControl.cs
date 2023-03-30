using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionControl : MonoBehaviour
{
    private static float range = 2f;  // 아이템 습득이 가능한 최대 거리
    private static bool pickupActivated = false;  // 아이템 습득 가능할시 True
    private static RaycastHit hit;  // 충돌체 정보 저장


    public static void TryAction(Transform transform)
    {
        CheckItem(transform);
        CanPickUp();
        // if(Input.GetKeyDown(KeyCode.E))
        // {
        //     CheckItem(transform);
        //     CanPickUp();
        // }
    }
    
    private static void CheckItem(Transform transform)
    {
		// Physics.SphereCast (레이저를 발사할 위치, 구의 반경, 발사 방향, 충돌 결과, 최대 거리)
		if (Physics.SphereCast (transform.position, 1f, transform.forward, out hit, range)){
            if(hit.transform.tag == "Item") {
                pickupActivated = true;
            }
        }
    }

    private static void CanPickUp()
    {
        if(pickupActivated)
        {
            if(hit.transform != null)
            {
                string itemName = hit.transform.GetComponent<ItemPickUp>().item.itemName;
                Debug.Log(itemName + " 획득 했습니다.");
                Destroy(hit.transform.gameObject);
                pickupActivated = false;

                if (itemName == "Time") {
                    GameManager.pickUpTime = true;
                } else {
                    GameManager.pickUpSpeed = true;
                }

            }
        }
    }
}