using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        //DontDestroyOnLoad(this);
    }

    //enemy
    [Header("Enemy")]
    public GameObject[] enemys;
    public int enemysCount;


    [Header("Player")]
    public GameObject player;

    //게임 플레이 중인지 검사하는 변수
    public bool isPlay;
    public GameObject ranking;

    void Start()
    {
        //존재하는 적들을 배열에 저장
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        enemysCount = enemys.Length;
        isPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        //적이 다 사라지면
        if (enemysCount == 0 && isPlay)
        {
            //게임 클리어
            UIManager.instance.GameClear();
            isPlay = false;
            ranking.GetComponent<ranking>().RankingUpdate();
        }
    }

}
