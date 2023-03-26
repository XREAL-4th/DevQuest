using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameoverText; // ���� ����� Ȱ��ȭ�� �ؽ�Ʈ
    Image timeBar;


    [SerializeField] float setTime = 60f; // �⺻�ð�
    float timeLeft; // �����ð�

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
            timeLeft -= Time.deltaTime; // ���� �ð� ���ҽ�Ű��
            timeBar.fillAmount = timeLeft / setTime;
        }

        else
        {
            gameoverText.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
