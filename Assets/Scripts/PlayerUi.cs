using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    //�÷��̾� ü�� ����
    public int hp = 20;
    //�ִ� ü�� ����
    int maxHp = 20;
    //ü�� �����̴� ����
    public Slider hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���� �÷��̾� ü���� ������ hp �����̴� ���� �ݿ�
        hpSlider.value = (float)hp / (float)maxHp;
    }
}
