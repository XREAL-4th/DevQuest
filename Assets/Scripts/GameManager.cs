using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject gameoverText; // ���� ����� Ȱ��ȭ�� �ؽ�Ʈ
    public Image timeBar;


    [SerializeField] float setTime = 60f; // �⺻�ð�
    float timeLeft; // �����ð�


    // �̱���
    static GameManager instance = null;
    public static GameManager Instance()
    {
        return instance;
    }



    void Awake()
    {
        if(instance == null) // �Ҵ� �� �� ������ �̰� �ֱ�
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        //DontDestroyOnLoad(this); // �ʱ�ȭ�Ǵ°� �����ֱ�
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
            timeLeft -= Time.deltaTime; // ���� �ð� ���ҽ�Ű��
            timeBar.fillAmount = timeLeft / setTime; //timebar ����
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
