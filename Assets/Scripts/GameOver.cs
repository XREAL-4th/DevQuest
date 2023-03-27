using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameoverText; // 게임 종료시 활성화할 텍스트
    Image timeBar;


    [SerializeField] float setTime = 60f; // 기본시간
    float timeLeft; // 남은시간

    void Start()
    {
        gameoverText.SetActive(false);
        timeBar = GetComponent<Image>();
        timeLeft = setTime;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime; // 남은 시간 감소시키기
            timeBar.fillAmount = timeLeft / setTime;
        }

        else
        {
            gameoverText.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
