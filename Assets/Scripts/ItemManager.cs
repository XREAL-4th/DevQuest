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
    [Header("Items")]
    public GameObject carrot;
    public GameObject box;


    void Start()
    {
        //������ ���� & �迭
        Instantiate(carrot);
        carrot.transform.position = new Vector3(-214, 0, 237);
        Instantiate(box);
        carrot.transform.position = new Vector3(-202, 0, 241);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
