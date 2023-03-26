using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        //���ϼ� ����
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(this);
    }

    //enemy
    [Header("Enemy")]
    public GameObject[] enemys;
    public int enemysCount;
    public GameObject player;

    [Header("UI")]
    public GameObject gameClear;

    void Start()
    {
        //�����ϴ� ������ �迭�� ����
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        enemysCount = enemys.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //���� �� �������
        if (enemysCount == 0)
        {
            //���� Ŭ����
            Debug.Log("game clear");
            gameClear.SetActive(true);
        }
    }
}
