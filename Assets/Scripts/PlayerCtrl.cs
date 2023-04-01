using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 300)
        {
            GameQuit(); //플레이 시간이 300초 넘어가면 게임을 종료하도록 함수 실행
        }

 

    }

    void GameQuit()
    {
        print("시간 초과로 게임종료");
        GameManager.instance.IsGameOver = true; //싱글턴 변수 사용하여 게임 종료
    }
}
