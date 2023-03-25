using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int score = 0;

    [SerializeField] float maxTime = 60f;
    float timeLeft;

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
        }
        else {
            GameOver();
        }
    }

    private void GameOver() {
        Debug.Log("Game Ended!");
        Debug.Log("Score: " + score);
        //score = 0;
        SceneManager.LoadScene(0);
    }
}