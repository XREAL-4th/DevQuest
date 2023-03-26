using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance = null;

    private void Awake()
    {
        //���ϼ� ����
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    //item
    public enum ItemType { name, damage, speed, itemPrefab }
    public List<ItemData> itemDatas = new List<ItemData>();


    void Start()
    {
        //������ ���� �� ��ġ �Լ� ȣ��
        ItemSpawn(itemDatas[0], new Vector3(-214, 1, 237));
        ItemSpawn(itemDatas[1], new Vector3(-202, 0, 241));
    }

    void ItemSpawn(ItemData _newItem, Vector3 _position)
    {
        //������ ���� �� ��ġ
        GameObject newItem = Instantiate(_newItem.itemPrefab);
        newItem.transform.position = _position;
    }
}
