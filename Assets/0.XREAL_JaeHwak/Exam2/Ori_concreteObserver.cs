using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ori_concreteObserver : MonoBehaviour,IObserver
{
    GameObject obj;
    public int cnt = 0;
    public bool is_End = false;
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
        is_End = true;
        EndingData.NewEndingData();
    }
}
