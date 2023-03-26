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
        Debug.Log("������ Ŭ���� �޼��� ����");
        cnt++;
        if(cnt == 4)
        {
            sendEnding();
        }
    }

    public void sendEnding()
    {
        Debug.Log("���� Ŭ����");

        text.text = "Ŭ����!";
        EndingData.NewEndingData();
        Invoke("destory_Text", 3f);
    }


    public void destory_Text()
    {
        text.text = "";
    }
}
