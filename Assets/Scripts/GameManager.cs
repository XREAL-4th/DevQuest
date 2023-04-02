using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private Transform world = null;
    [SerializeField]
    private Factory itemFactory = null;
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
        for (int i = 0; i<20; i++)
        {
            int randomType = Random.Range(0, 2);
            this.itemFactory.Spawn((ITEM)randomType, this.world);
        }
        ExitPanel.SetActive(false);
    }
    public GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
    public GameObject Player;
    public MoveControl MoveControl;
    public GameObject ExitPanel;
    public bool ExitButtonClicked = false;

    private void Update()
    {
        if (ExitButtonClicked)
        {
            Time.timeScale = 0f;
            ExitPanel.SetActive(true);
        }
    }

    public void ExitYes()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void ExitNo()
    {
        ExitButtonClicked = false;
        ExitPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitButton()
    {
        ExitButtonClicked = true;
    }
}
