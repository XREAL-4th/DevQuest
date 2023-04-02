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

    //UI GameObject들
    public Text Sec;
    public GameObject CoolTimePanel;
    public GameObject CoolTimePannel_1;
    public GameObject SecObject; //초 숫자
    public GameObject CoolTimeSec; //( )초




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
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.yellow, 1000); //카메라의 position, 방향 위치로 Ray 그림

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)) // 충돌이 검출되면 총알의 리스폰포인트(firePos)가 충돌이 발생한위치를 바라 봄.

        {
            firePos.LookAt(hit.point);
            Debug.DrawRay(firePos.position, firePos.forward, Color.grey, 1000);

            if (Input.GetKeyDown(KeyCode.Q)) //S 키를 눌렀을 때, 딱 한번 true를 반환
            {
                Debug.Log("Q 누름");

                if (setCooltime == true)
                {

                    Bomb();
                    setCooltime = false;
                    time = 10;
                    //GameManager.instance.time = 0; //게임매니저의 쿨타임 세주는 것도 0으로 초기화
                    StartCoroutine(fireBomb()); //쿨타임 시간 다시 세기

                }
                else
                {
                    print("아직 cooltime이 다 안찼다.");
                }
                //StartCoroutine(fireBomb());
            }
                
        }

        else
        {
            Debug.DrawRay(firePos.position, firePos.forward, Color.black, 1000);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("공중을 향해서는 폭탄을 발사할 수 없다.");
                //공중을 향해 폭탄 발사
            }

        }


        //UI 관리
        //print("유아이 매니저:" + GameObject.Find("PlayerSkill").GetComponent<PlayerSkill>().time.ToString());
        Sec.text = time.ToString(); //쿨타임 시간 UI

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
            print("현재 쿨타임은: " + time + "초");
        }


        //print(GameManager.instance.coolTime());

        //yield return new WaitForSeconds(10.0f); //10초 기다려

        //print("쿨 타임 시간: "+new WaitForSeconds(GameManager.instance.cooltime));
        //yield return new WaitForSeconds(10.0f); //10초 기다림
        setCooltime = true;
        print("cooltime 다 찼다.");

        //
        //Instantiate(bomb, firePos.position, firePos.rotation); //Bomb 프리팹 생성
        
        //yield return null;

    }

    void Bomb()
    {
        Instantiate(bomb, firePos.position, firePos.rotation); //Bomb 프리팹 생성
    }




}
