using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSys : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject AimUI;
    [SerializeField] GameObject SettingUI;
    [SerializeField] GameObject LeaveUI;
    [Header("State")]
    [SerializeField] public State nowState;
    private State nextState;

    public enum State
    {
        init,
        Play,
        Setting,
        Quit
    }

    private void Start()
    {
        nowState = State.init;
        nextState = State.Play;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            switch(nowState)
            {
                case State.Play:
                    nextState = State.Setting;
                    break;
                case State.Setting:
                    nextState = State.Play;
                    break;
                case State.Quit:
                    nextState = State.Setting;
                    break;
                default:
                    break;
            }
        }

        if (nowState != nextState)
        {
            nowState = nextState;
            switch(nowState)
            {
                case State.Play:
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    AimUI.SetActive(true);
                    //SettingUI.SetActive(false); //vr
                    LeaveUI.SetActive(false);
                    break;
                case State.Setting:
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    AimUI.SetActive(false);
                    SettingUI.SetActive(true);
                    LeaveUI.SetActive(false);
                    break;
                case State.Quit:
                    LeaveUI.SetActive(true);
                    SettingUI.SetActive(false); //vr
                    break;
                default:
                    break;

            }
        }
    }

    public void ButtonToPlay()
    {
        nextState = State.Play;
    }
    public void ButtonToSetting()
    {
        nextState = State.Setting;
    }
    public void ButtonToQuit()
    {
        nextState = State.Quit;
    }
    public void ButtonToOffGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //에디터에서 작동
        #else
				Application.Quit(); // 빌드 시 작동
        #endif
    }
}
