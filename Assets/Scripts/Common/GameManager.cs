using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public List<Transform> enemyPoints; // Enemy Location
    public GameObject[] enemies;    // Enemy Prefab
    public float createTime = 2.0f;
    public int maxEnemy = 4;

    public int killEnemy = 0;
    public int goal = 5;            // goal -> Fin Game

    public bool isGameOver = false;
    public GameObject GameFinUI;

    public static GameManager instance = null;

    public static GameManager Instance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) 
        {
            Destroy(this.gameObject); 
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        Init();                         // GameManager Init
        ItemManager.instance.Init();    // ItemManager Init
    }

    public void Init()
    {
        enemyPoints = new List<Transform>(GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>());

        if (enemyPoints.Count > 0)
        {
            StartCoroutine(this.CreateEnemy());
        }
    }

    IEnumerator CreateEnemy()
    {
        while(!isGameOver)
        {
            int enemyCount = (int)GameObject.FindGameObjectsWithTag("ENEMY").Length;

            if (enemyCount < maxEnemy)
            {
                yield return new WaitForSeconds(createTime);

                int pointIdx = UnityEngine.Random.Range(1, enemyPoints.Count);
                int enemyIdx = UnityEngine.Random.Range(0, enemies.Length);

                Instantiate(enemies[enemyIdx], enemyPoints[pointIdx].position, enemyPoints[pointIdx].rotation, GameObject.Find("Enemies").transform);

            }
            else yield return null;
        }
    }

    void Update()
    {
        if (killEnemy >= goal && isGameOver == false)
        {
            isGameOver = true;

            // 게임 종료 UI를 띄움
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            Instantiate(GameFinUI, new Vector3(Camera.main.pixelWidth/2, Camera.main.pixelHeight / 2), Quaternion.identity, GameObject.Find("Canvas").transform);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Assignment");

        killEnemy = 0; 
        isGameOver = false;

        // Manager Init
        enemyPoints.Clear();
        instance.Init();
        ItemManager.instance.Init();
    }
}
