using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 60)
        {
            GameQuit(); //�÷��� �ð��� 60�� �Ѿ�� ������ �����ϵ��� �Լ� ����
        }

 

    }

    void GameQuit()
    {
        print("�ð� �ʰ��� ��������");
        GameManager.instance.IsGameOver = true; //�̱��� ���� ����Ͽ� ���� ����
    }
}
