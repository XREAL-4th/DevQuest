using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ori_concreteObserver : MonoBehaviour,IObserver
{
    GameObject obj;
    public int cnt = 0;
    public Text text;
    public void OnNotify()
    {
        Debug.Log("------------------------------------------------");
        Debug.Log("옵저버 클래스 메서드 실행");
        cnt++;
        if(cnt == 4)
        {
            sendEnding();
        }
    }

    public void sendEnding()
    {
        Debug.Log("게임 클리어");

        text.text = "클리어!";
        EndingData.NewEndingData();
        Invoke("destory_Text", 3f);
    }


    public void destory_Text()
    {
        text.text = "";
    }
}
