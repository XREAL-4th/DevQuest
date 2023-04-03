using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowScore : MonoBehaviour
{
    public Text Score;
    public Text BestScore;
    public int Scoreint;
    public int BestScoreint;
    public Text PlayerName;
    public Text BestPlayerName;

    void Start()
    {
        Scoreint = GameManager.Instance.DeadEnemy();
        Score.text = Scoreint.ToString();
        PlayerName.text = GameManager.Instance.GetPlayerName();

        if (PlayerPrefs.HasKey("BestScore"))
        {
            BestScoreint = int.Parse(PlayerPrefs.GetString("BestScore"));

            //UnityEngine.Debug.Log(shortestText + " " + exitTime.text);
            if (Scoreint > BestScoreint)
            {
                PlayerPrefs.SetString("BestScore", Score.text);
                PlayerPrefs.SetString("BestPlayerName", PlayerName.text);

            }
        }
        else
        {
            //UnityEngine.Debug.Log(exitTime.text);
            PlayerPrefs.SetString("BestScore", Score.text);
            PlayerPrefs.SetString("BestPlayerName", PlayerName.text);
        }
        BestScore.text = PlayerPrefs.GetString("BestScore");
        BestPlayerName.text = PlayerPrefs.GetString("BestPlayerName");
    }

}
