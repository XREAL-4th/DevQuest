using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    private void Awake()
    {
        //���ϼ� ����
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    [Header("UI")]
    public GameObject gameClear;

    public void GameClear()
    {
        gameClear.SetActive(true);
    }

}
