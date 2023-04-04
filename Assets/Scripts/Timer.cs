using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private TMP_Text timer;
    public bool isPlay;
    void Start()
    {
        //시간 초기화
        time = 0;
        timer.text = "Time : " + time + " s";
    }

    void Update()
    {
        isPlay = GameManager.instance.isPlay;
        //플레이 중이라면
        if (isPlay)
        {
            time += Time.deltaTime;
            timer.text = "Time : " + (int)time + "s";
        }
    }

    public float getTime()
    {
        return time;
    }
}
