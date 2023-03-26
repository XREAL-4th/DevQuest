using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingTimeLabel : MonoBehaviour
{
    public Text text;
    [SerializeField] private Ori_concreteObserver observer;
    private bool all_finish = false;
    // Start is called before the first frame update
    private void Update()
    {
        if(observer.is_End == true && all_finish == false)
        {
            EndingData endingData = EndingData.GetEndingData();

            int cnt = endingData.cnt;
            text.text = "클리어!\n" + cnt + "마리 처치";
            Invoke("destory_Text", 3f);
            all_finish = true; //Update 내 ending 반복 실행 방지
        }
    }
    public void destory_Text()
    {
        text.text = "";
    }

}
