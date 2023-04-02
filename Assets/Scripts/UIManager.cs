using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public GameObject QuitPanel; //팝업 게임오브젝트
    public Text Sec;


    // Start is called before the first frame update
    void Start()
    {
        QuitPanel.SetActive(false); //팝업해제되어 있는 상태로 시작
        //Sec.text = "하이";
    }

    // Update is called once per frame
    void Update()
    {
        print("유아이 매니저:" + GameObject.Find("PlayerSkill").GetComponent<PlayerSkill>().time.ToString());
        Sec.text = GameObject.Find("PlayerSkill").GetComponent<PlayerSkill>().time.ToString(); //쿨타임 시간 UI
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
        QuitPanel.SetActive(true); //팝업생성
        Time.timeScale = 0; //시간정지, 팝업이 뜨면 게임을 일시정지함.


    }


    public void PanelOFF()
    {
        QuitPanel.SetActive(false); //팝업해제
        Time.timeScale = 1; //일시정지 해제
    }


}
