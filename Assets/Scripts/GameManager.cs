using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool isGameOver; //게임 종료 여부를 저장할 멤버 변수

    public int score = 0; //죽인 적의 수 

    public bool IsGameOver
    {
        get { return isGameOver; } //getter 영역: 외부에서 프로퍼티를 읽을 때 실행되는 영역: 

        set
        {
            isGameOver = value;
            if (isGameOver = value)
            {
                print("게임종료");
                Application.Quit();
                Quit(); //유니티 에디터에서 게임종료

            }
        } //setter 영역: 값을 저장할 때 실행되는 영역. 프로퍼티에 값을 대입하면 그 값은 value 키워드를 통해 전달
    }

    public static GameManager instance = null; //싱글턴 인스턴스 선언


    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } //인스턴스가 할당되지 않았을 경우

        else if (instance != this)
        {
            Destroy(this.gameObject);
        } //인스턴스에 할당된 클라스의 인스턴스가 다를 경우 새로 생성된 클래스를 의미

        DontDestroyOnLoad(this.gameObject); //다른 씬으로 넘어가더도 삭제되지 않고 유지
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score()
    {
        score++; //적을 한 명 죽이면 score +1
        print("현재 죽인 적의수 =" + score);
        if (score >= 5)
        {
            print("적을 5명이상 죽여서 게임종료");
            IsGameOver = true;//isGameOver 실행
        }
    }


    public static void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
                 Application.OpenURL(webplayerQuitURL);
        #else
                 Application.Quit();
        #endif
    }
}
