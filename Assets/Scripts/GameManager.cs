using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int GameScore;
    public float GameTime;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Fire.score >= 35)
        {
            GameScore = Fire.score;
            GameTime = Timer.timeleft;
            SceneManager.LoadScene("GameClear");
        }
        if (Timer.timeleft <= 0 && Fire.score<35)
        {
            GameScore = Fire.score;
            GameTime = Timer.timeleft;
            SceneManager.LoadScene("GameOver");
        }
    }
}
