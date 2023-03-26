using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int score = 0;
    [SerializeField] float maxTime = 30f;
    float timeLeft;
    [SerializeField] TextMeshProUGUI infoLabel;

    public void Awake() {
        if (instance == null) {
            instance = this; // 내 자신을 instance로
            //DontDestroyOnLoad(gameObject); // 씬 로드 시 유지
        }
        else {
            // 이미 instance 존재하는 경우
            if (instance != this) {
                Destroy(this.gameObject); // 방금 Awake된 자신을 삭제
            }
        }
    }

    private void Start() {
        timeLeft = maxTime;
    }

    private void Update() {
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            infoLabel.text = "Time: " + (int)timeLeft + "\r\nScore: " + score;
        }
        else {
            GameOver();
        }
    }

    private void GameOver() {
        infoLabel.text = "Game Over!\r\nScore: " + score;
        //SceneManager.LoadScene(5);
    }
}