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
        //유일성 보장
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
        //존재하는 적들을 배열에 저장
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        enemysCount = enemys.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //적이 다 사라지면
        if (enemysCount == 0)
        {
            //게임 클리어
            Debug.Log("game clear");
            gameClear.SetActive(true);
        }
    }
}
