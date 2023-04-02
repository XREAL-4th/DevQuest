using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public GameObject QuitPanel; //�˾� ���ӿ�����Ʈ
    public Text Sec;


    // Start is called before the first frame update
    void Start()
    {
        QuitPanel.SetActive(false); //�˾������Ǿ� �ִ� ���·� ����
        //Sec.text = "����";
    }

    // Update is called once per frame
    void Update()
    {
        print("������ �Ŵ���:" + GameObject.Find("PlayerSkill").GetComponent<PlayerSkill>().time.ToString());
        Sec.text = GameObject.Find("PlayerSkill").GetComponent<PlayerSkill>().time.ToString(); //��Ÿ�� �ð� UI
    }


    public void GameQuit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
                 Application.OpenURL(webplayerQuitURL);
        #else
                 Application.Quit();
        #endif
    }

    public void PanelOn()
    {
        //QuitPanel = GameObject.Find("QuitPanel");
        QuitPanel.SetActive(true); //�˾�����
        Time.timeScale = 0; //�ð�����, �˾��� �߸� ������ �Ͻ�������.


    }


    public void PanelOFF()
    {
        QuitPanel.SetActive(false); //�˾�����
        Time.timeScale = 1; //�Ͻ����� ����
    }


}
