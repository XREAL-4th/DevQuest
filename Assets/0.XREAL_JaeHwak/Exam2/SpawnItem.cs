using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public static SpawnItem main;
    public enum ItemType {speedUp, speedDown, bulletPlus};
    public List<ItemData> ItemDatas = new List<ItemData>();
    [HideInInspector] public GameObject itemPrefab; //Item ������ ��������

    private void Awake()
    {
        //���� : ���� public static SpawnItem main;�� Awake �Լ� �� main = this �� ������ ��� �̱����� �Ǵ� ���ΰ���?
        main = this;
        //���� : HideInInspector�� �������� �ҷ����� ���� Resources.Load �� ����߽��ϴ�. �ش� ����� �ùٸ� ����ϱ��? �ƴϸ� �̿��� ����� �������?
        itemPrefab = Resources.Load<GameObject>("Item");
    }

    private void Start()
    {
        SpawnItemObject();
    }

    public void SpawnItemObject()
    {
        for (int set = 0; set < 5; set++)
        {
            for (int i = 0; i < ItemDatas.Count; i++)
            {
                var item = SpawnItemFunc((ItemType)i);
                item.WatchItemInfo();
            }
        }
    }

    //���� : SO�� ����� �������� ���� �� ��ġ �� �׸��� �ν��Ͻ� ���� ���� ����ؾ� �� �� ������ ��� �ۼ��ϸ� ���� �� �ñ��մϴ�.
    public Item SpawnItemFunc(ItemType type)
    {
        //������ ���� �� ���� ��ġ ������ ����
        float x = Random.Range(-14, 14);
        float y = 0.6f;
        float z = Random.Range(-14, 14);
        Vector3 pos = new Vector3(x, y, z);

        var newItem = Instantiate(itemPrefab, pos, Quaternion.identity).GetComponent<Item>();
        newItem.ItemData = ItemDatas[(int)(type)];

        return newItem;
    }

}
