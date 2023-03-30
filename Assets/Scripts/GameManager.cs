using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�̱��� ���� : �� ���� Ŭ���� �ν��Ͻ��� ������ �����ϰ�, �̿� ���� �������� ������ ����
    public static GameManager gm;

    private float GameTime = 15;
    public Text GameTimeText;

    //���� ���� UI ������Ʈ ����
    public GameObject gameLabel;
    //UI �ؽ�Ʈ ������Ʈ ����
    Text gameText;

    private void Awake()
    {
        gm = this;
    }

 

    // Update is called once per frame
    void Update()
    {
        if ((int)GameTime == 0)
        {
            SceneManager.LoadScene("Ending");
        }
        else
        {
            GameTime -= Time.deltaTime;
            
        }
    }
}
