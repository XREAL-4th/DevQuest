using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameQuitManager : MonoBehaviour
{

    private static GameQuitManager instance = null;
    private static int deadEnemy = 0;
    

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

    public static GameQuitManager Instance
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

}
