using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField]
    ItemData itemData;
    public ItemData ItemData { set { itemData = value; } }
    public TMP_Text itemName;
    public GameObject gun;
    public void WatchItemInfo()
    {
        Debug.Log(itemData.ItemName);
        Debug.Log(itemData.Des);
        Debug.Log(itemData.Fre);
        Debug.Log(itemData.Speed);
        Debug.Log(itemData.Material);
        Debug.Log(itemData.SP);
    }

    private void Start()
    {
        //아이템 별 색상, 이름 초기 지정
        gameObject.GetComponent<MeshRenderer>().material = itemData.Material;
        itemName.text = itemData.ItemName;
    }

    //아이템 종류 파악 및 특수 효과 실행
    private void OnTriggerEnter(Collider other)
    {
        //아이템 레이어는 플레이어와만 충돌하도록 physics 설정을 하였습니다.
        //추후 VR playerContorl로 변경하여 동작하도록 수정하겠습니다.
/*        switch (itemData.SP)
        {
            case 0: //speedUp
                other.gameObject.GetComponent<MoveControl>().speedChange(itemData.Speed);
                break;
            case 1: //speedDown
                other.gameObject.GetComponent<MoveControl>().speedChange(itemData.Speed);
                break;
            case 2: //multiArrow //총과 총은 Bullet 레이어로 설정한 후 Physics 레이어에서 서로의 충돌을 꺼 주었습니다.
                var multiGun = Instantiate(gun);
                multiGun.transform.parent = other.transform.GetChild(0);
                //other.transform.GetChild(0) Player->MainCamera 의 자식으로 설정
                multiGun.transform.localPosition = new Vector3(0.114f * other.transform.GetChild(0).childCount, -0.03f, 0.713f);
                // other.transform.GetChild(0).childCount - 추가 생성 총의 경우 생성된 우측으로 생성
                multiGun.transform.localRotation = Quaternion.Euler(0, -90, 0);
                break;
        }*/
        Destroy(gameObject);
    }
}
