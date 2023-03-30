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
