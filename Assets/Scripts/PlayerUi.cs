using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HPEvent : UnityEngine.Events.UnityEvent<int, int> { }

public class PlayerUi : MonoBehaviour
{
    [HideInInspector]
    public HPEvent onHPEvent = new HPEvent();

    [Header("HP")]
    [SerializeField]
    //플레이어 체력 변수
    private int maxHp = 100;
    private int currenthp;
    //체력 슬라이더 변수
    public Slider hpSlider;

    public int CurrentHP => currenthp;
    public int MaxHP => maxHp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //현재 플레이어 체력의 비율을 hp 슬라이더 값에 반영
        hpSlider.value = (float)currenthp / (float)maxHp;
    }


    public void IncreaseHP(int hp)
    {
        int previousHP = CurrentHP;
        currenthp = currenthp + currenthp > maxHp ? maxHp : currenthp + currenthp;
        onHPEvent.Invoke(previousHP, CurrentHP);
    }
}
