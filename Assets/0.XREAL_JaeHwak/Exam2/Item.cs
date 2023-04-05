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
        //������ �� ����, �̸� �ʱ� ����
        gameObject.GetComponent<MeshRenderer>().material = itemData.Material;
        itemName.text = itemData.ItemName;
    }

    //������ ���� �ľ� �� Ư�� ȿ�� ����
    private void OnTriggerEnter(Collider other)
    {
        //������ ���̾�� �÷��̾�͸� �浹�ϵ��� physics ������ �Ͽ����ϴ�.
        //���� VR playerContorl�� �����Ͽ� �����ϵ��� �����ϰڽ��ϴ�.
/*        switch (itemData.SP)
        {
            case 0: //speedUp
                other.gameObject.GetComponent<MoveControl>().speedChange(itemData.Speed);
                break;
            case 1: //speedDown
                other.gameObject.GetComponent<MoveControl>().speedChange(itemData.Speed);
                break;
            case 2: //multiArrow //�Ѱ� ���� Bullet ���̾�� ������ �� Physics ���̾�� ������ �浹�� �� �־����ϴ�.
                var multiGun = Instantiate(gun);
                multiGun.transform.parent = other.transform.GetChild(0);
                //other.transform.GetChild(0) Player->MainCamera �� �ڽ����� ����
                multiGun.transform.localPosition = new Vector3(0.114f * other.transform.GetChild(0).childCount, -0.03f, 0.713f);
                // other.transform.GetChild(0).childCount - �߰� ���� ���� ��� ������ �������� ����
                multiGun.transform.localRotation = Quaternion.Euler(0, -90, 0);
                break;
        }*/
        Destroy(gameObject);
    }
}
