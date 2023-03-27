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
    //�÷��̾� ü�� ����
    private int maxHp = 100;
    private int currenthp;
    //ü�� �����̴� ����
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
        //���� �÷��̾� ü���� ������ hp �����̴� ���� �ݿ�
        hpSlider.value = (float)currenthp / (float)maxHp;
    }


    public void IncreaseHP(int hp)
    {
        int previousHP = CurrentHP;
        currenthp = currenthp + currenthp > maxHp ? maxHp : currenthp + currenthp;
        onHPEvent.Invoke(previousHP, CurrentHP);
    }
}
