using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartBtnClick : MonoBehaviour
{
    public void Click()
    {
        GameManager.Instance.ResetDeadEnemy();
        SceneManager.LoadScene("TitleScene");
    }
}
