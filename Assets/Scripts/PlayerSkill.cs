using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{

    public GameObject bomb;
    public Transform firePos;

    public bool cooltime = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fireBomb());
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.yellow, 1000); //ī�޶��� position, ���� ��ġ�� Ray �׸�

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)) // �浹�� ����Ǹ� �Ѿ��� ����������Ʈ(firePos)�� �浹�� �߻�����ġ�� �ٶ� ��.

        {
            firePos.LookAt(hit.point);
            Debug.DrawRay(firePos.position, firePos.forward, Color.grey, 1000);

            if (Input.GetKeyDown(KeyCode.Q)) //S Ű�� ������ ��, �� �ѹ� true�� ��ȯ
            {
                Debug.Log("Q ����");

                if (cooltime == true)
                {
                    Bomb();
                    cooltime = false;
                    StartCoroutine(fireBomb()); //��Ÿ�� �ð� �ٽ� ����

                }
                else
                {
                    print("���� cooltime�� �� ��á��.");
                }
                //StartCoroutine(fireBomb());
            }
                
        }

        else
        {
            Debug.DrawRay(firePos.position, firePos.forward, Color.black, 1000);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("������ ���ؼ��� ��ź�� �߻��� �� ����.");
                //������ ���� ��ź �߻�
            }

        }
    }

    IEnumerator fireBomb()
    {

        //print("a");
        yield return new WaitForSeconds(10.0f); //10�� ��ٸ�
        cooltime = true;
        print("cooltime �� á��.");

        //
        //Instantiate(bomb, firePos.position, firePos.rotation); //Bomb ������ ����
        
        //yield return null;

    }

    void Bomb()
    {
        Instantiate(bomb, firePos.position, firePos.rotation); //Bomb ������ ����
    }




}
