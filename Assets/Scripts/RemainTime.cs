using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainTime : MonoBehaviour
{
    public TMP_Text timeText;
    public static float rTime = GameManager.GetPlayTime();

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        PickUpTime();
        rTime -= Time.deltaTime;
        if (rTime < 0)
            rTime = 0;
        timeText.text = "time(s) " + Mathf.Round(rTime);
    }

    void BonusTime()
    {
        rTime += 5f;
        Debug.Log("시간이 5초 늘어났습니다!");
    }

    void PickUpTime() {
        if (GameManager.pickUpTime) {
            BonusTime();
            GameManager.pickUpTime = false;
        }
    }
}
