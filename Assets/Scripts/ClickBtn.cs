using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickBtn : MonoBehaviour
{
    public GameObject Popup;
    public static bool IsPause = false;

    public void ExitClick()
    {
        IsPause = true;
        Time.timeScale = 0.1f;
        Popup.SetActive(true);

    }

    public void ExitNoClick()
    {
        Popup.SetActive(false);
        IsPause = false;
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void ExitYesClick()
    {
        Application.Quit();
    }

    public void RestartClick()
    {
        GameManager.Instance.ResetDeadEnemy();
        SceneManager.LoadScene("TitleScene");
    }

    public void StartClick()
    {
        SceneManager.LoadScene("Assignment");
    }
}
