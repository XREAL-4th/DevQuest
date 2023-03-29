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
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(this);
    }

    //enemy
    [Header("Enemy")]
    public GameObject[] enemies;
    public int enemiesCount;
    public GameObject player;

    void Start()
    {
        //Enemy Tag를 가진 오브젝트를 배열에 저장
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesCount = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {

        if (enemiesCount == 0)
        {
            Debug.Log("game clear");
        }
    }
}