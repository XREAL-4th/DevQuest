using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;
    private static int deadEnemy = 0;
    private static string PlayerName;

    public GameObject Popup;
    public GameObject Canvas;
    public static bool IsPause = false;

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

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four) && IsPause == false || Input.GetKeyDown(KeyCode.Y))//exit
        {
            IsPause = true;
            Time.timeScale = 0.1f;
            Popup.SetActive(true);
        }

        if (OVRInput.GetDown(OVRInput.Button.Four) && IsPause == true)//exit yes
        {
            Application.Quit();
        }

        if (OVRInput.GetDown(OVRInput.Button.Three) && IsPause == true || Input.GetKeyDown(KeyCode.X))//exit no
        {
            Popup.SetActive(false);
            IsPause = false;
            Time.timeScale = 1;
            Cursor.visible = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.Start))//start
        {
            SceneManager.LoadScene("Assignment");
        }
    }

}
