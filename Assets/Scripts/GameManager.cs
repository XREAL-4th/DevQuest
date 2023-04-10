using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤 변수 : 한 개의 클래스 인스턴스를 갖도록 보장하고, 이에 대한 전역적인 접근점 제공
    public static GameManager gm;

    private float GameTime = 15;
    public Text GameTimeText;

    //게임 상태 UI 오브젝트 변수
    public GameObject gameLabel;
    //UI 텍스트 컴포넌트 변수
    Text gameText;

    //게임 종료 UI 오브젝트 변수
    public GameObject menuSet;

    //VR 게임 종료 UI 오브젝트 변수
    public GameObject menuVR;

    //게임 종료 버튼 오브젝트 변수
    public GameObject menuButton;

    private void Awake()
    {
        gm = this;
    }

 

    // Update is called once per frame
    void Update()
    {
        
        //종료 메뉴   
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                menuButton.SetActive(true);
            }
            else
            {
                menuSet.SetActive(true);
                menuButton.SetActive(false);

            }
                
        }
        //종료 메뉴 실행 및 종료 버튼 활성
        if (menuSet.activeSelf)
        {
            if (Input.GetKey(KeyCode.Y))
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            if (Input.GetKey(KeyCode.N))
            {
                menuSet.SetActive(false);
            }
           
        }
        //VR 종료 메뉴 실행 및 종료 버튼 활성
        if (menuVR.activeSelf)
        {
            if (Input.GetButton("Yes"))
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            if (Input.GetButton("No"))
            {
                menuSet.SetActive(false);
            }
        }
       


        if ((int)GameTime == 0)
        {
            SceneManager.LoadScene("Ending");
        }
        else
        {
            GameTime -= Time.deltaTime;
            
        }
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
