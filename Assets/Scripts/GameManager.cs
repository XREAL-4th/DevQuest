using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;
    private static int deadEnemy = 0;
    private static string PlayerName;
    

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void KillEnemy()
    {
        deadEnemy += 1;
    }

    public void ShowDeadEnemy()
    {
        Debug.Log(deadEnemy);
    }

    public int DeadEnemy()
    {
        return deadEnemy;
    }

    public void FinishGame()
    {
        SceneManager.LoadScene("Ending"); 
    }

    public void ResetDeadEnemy()
    {
        deadEnemy = 0;
    }

    public void SetPlayerName(string inputname)
    {
        PlayerName = inputname;
    }

    public string GetPlayerName()
    {
        return PlayerName;
    }

}
