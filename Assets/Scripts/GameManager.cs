using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{   
    [SerializeField] static float playTime = 40f;

    public GameObject player;
    public TMP_Text scoreText;
    public static bool pickUpTime = false;
    public static bool pickUpSpeed = false;
    
    private static GameManager main;

    bool DEBUG = false;
    private static int score = 0;
    private static bool gameStart = false;
    
    void Awake() {
        if(GameManager.main != null && GameManager.main != this){
            Destroy(gameObject);
        } else GameManager.main = this;
        
        // DontDestroyOnLoad(this);
    }

    public void Start(){
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        // Invoke("ReStartGame", 3f);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score: " + score;
        EndTime();
    }

    public static float GetPlayTime() {
        return playTime;
    }
    
    public static int GetScore() {
        return score;
    }

    public void ReStartGame() {
        if(DEBUG) {Debug.Log("Total Score " + score);}
        // else player.GetComponent<MoveControl>().canShoot = true;
        Time.timeScale = 1;
        RemainTime.rTime = playTime;
        SceneManager.LoadScene("penguinGame", LoadSceneMode.Single);
        // SceneManager.LoadScene("Result", LoadSceneMode.Single);
        if(DEBUG) {Debug.Log("Restarted");}
    }

    public void Ending() {
        SceneManager.LoadScene("Result", LoadSceneMode.Single);
    }

    public static void CalScore(){
        score++;
    }
    
    void EndTime(){
        if (RemainTime.rTime <= 0 || score == 3){
            Time.timeScale = 0;
            DEBUG = true;
            Ending();
            // ReStartGame();
        }
    }
}
