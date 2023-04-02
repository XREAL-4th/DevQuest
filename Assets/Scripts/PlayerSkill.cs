using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{

    public GameObject bomb;
    public Transform firePos;

    public bool setCooltime = false;

    public int time = 10;

    //UI GameObject��
    public Text Sec;
    public GameObject CoolTimePanel;
    public GameObject CoolTimePannel_1;
    public GameObject SecObject; //�� ����
    public GameObject CoolTimeSec; //( )��




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fireBomb());
        time = 10;
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

                if (setCooltime == true)
                {

                    Bomb();
                    setCooltime = false;
                    time = 10;
                    //GameManager.instance.time = 0; //���ӸŴ����� ��Ÿ�� ���ִ� �͵� 0���� �ʱ�ȭ
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


        //UI ����
        //print("������ �Ŵ���:" + GameObject.Find("PlayerSkill").GetComponent<PlayerSkill>().time.ToString());
        Sec.text = time.ToString(); //��Ÿ�� �ð� UI

        if (setCooltime == true)
        {
            CoolTimePanel.SetActive(false);
            CoolTimePannel_1.SetActive(true);
            SecObject.SetActive(false);
            CoolTimeSec.SetActive(false);


        }
        else
        {
            CoolTimePanel.SetActive(true);
            CoolTimePannel_1.SetActive(false);
            SecObject.SetActive(true);
            CoolTimeSec.SetActive(true);

        }
    }

    IEnumerator fireBomb()
    {

        //print("a");

        /*
        print(time);
        yield return new WaitForSeconds(1.0f);
        time += 1;
        yield return new WaitForSeconds(1.0f);
        time += 1;
        */


        while (time != 0)
        {
            yield return new WaitForSeconds(1.0f);
            time -= 1;
            print("���� ��Ÿ����: " + time + "��");
        }


        //print(GameManager.instance.coolTime());

        //yield return new WaitForSeconds(10.0f); //10�� ��ٷ�

        //print("�� Ÿ�� �ð�: "+new WaitForSeconds(GameManager.instance.cooltime));
        //yield return new WaitForSeconds(10.0f); //10�� ��ٸ�
        setCooltime = true;
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
