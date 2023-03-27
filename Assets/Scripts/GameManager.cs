using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject gameoverText; // 게임 종료시 활성화할 텍스트
    public Image timeBar;


    [SerializeField] float setTime = 60f; // 기본시간
    float timeLeft; // 남은시간


    // 싱글톤
    static GameManager instance = null;
    public static GameManager Instance()
    {
        return instance;
    }



    void Awake()
    {
        if(instance == null) // 할당 된 거 없으면 이거 넣기
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        //DontDestroyOnLoad(this); // 초기화되는거 막아주기
    }

    private void Start()
    {
        gameoverText.SetActive(false);
        timeBar = GetComponent<Image>();
        timeLeft = setTime;
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime; // 남은 시간 감소시키기
            timeBar.fillAmount = timeLeft / setTime; //timebar 감소
        }

        else
        {
            gameoverText.SetActive(true);
            Time.timeScale = 0;

            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Gmae Over");
    }
}
