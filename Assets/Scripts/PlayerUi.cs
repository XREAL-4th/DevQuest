using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    //플레이어 체력 변수
    public int hp = 20;
    //최대 체력 변수
    int maxHp = 20;
    //체력 슬라이더 변수
    public Slider hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //현재 플레이어 체력의 비율을 hp 슬라이더 값에 반영
        hpSlider.value = (float)hp / (float)maxHp;
    }
}
