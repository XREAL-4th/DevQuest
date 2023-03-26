using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingData : MonoBehaviour
{
    public Ori_concreteObserver observer;
    public int cnt;

    public static void NewEndingData()
    {
        GameObject e = GameObject.FindGameObjectWithTag("LastEndingData");
        if (e != null) Destroy(e);
        e = new GameObject("EndingData");
        e.tag = "LastEndingData";
        e.AddComponent<EndingData>();
        DontDestroyOnLoad(e);
    }
    public static EndingData GetEndingData()
    {
        return GameObject.FindGameObjectWithTag("LastEndingData").GetComponent<EndingData>();
    }
    public void Start()
    {
        cnt = observer.cnt;
    }

}
