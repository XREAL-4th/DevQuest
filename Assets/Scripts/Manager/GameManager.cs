using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private float timeLimit = 30f;

    public GameObject player;
    // UI-Text 
    public Text timerText;
    public Text coinText;
    public Text playerScoreText;
    public Text enemyScoreText;
    public int playerScore;
    public int enemyScore;
    
    private float timer;
    public bool isPlaying = false;
    private float remainTime;
    public int remainCoin;
    public float moveSpeed;
    
    
    private void Start()
    {
        timer = 0f;
        isPlaying = true;
        moveSpeed = 1f;
    }

    private void Update()
    {
        if (isPlaying && EnemySpawner.instance.remainEnemyCount > 0)
        {
            timer += Time.deltaTime; // 경과 시간 누적

            remainTime = timeLimit - timer;
            if (remainTime < 0)
            {
                remainTime = 0f;
                isPlaying = false;
            }
            timerText.text = "Time : " + Mathf.Round(remainTime);
        }
        else if(!isPlaying && EnemySpawner.instance.remainEnemyCount > 0)
        {
            if (remainTime <= 0f)
            {
                timerText.text = "Time Over";
                isPlaying = false;
            }
        }
        coinText.text = "Coin : " + remainCoin;
        playerScoreText.text = "Player Score : " + playerScore;
        enemyScoreText.text = "Enemy Score : " + enemyScore;
    }

    public void GameClear()
    {
        timerText.text = "Game Clear!";
    }
}
