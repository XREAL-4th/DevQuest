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
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.yellow, 1000); //카메라의 position, 방향 위치로 Ray 그림

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)) // 충돌이 검출되면 총알의 리스폰포인트(firePos)가 충돌이 발생한위치를 바라 봄.

        {
            firePos.LookAt(hit.point);
            Debug.DrawRay(firePos.position, firePos.forward, Color.grey, 1000);

            if (Input.GetKeyDown(KeyCode.Q)) //S 키를 눌렀을 때, 딱 한번 true를 반환
            {
                Debug.Log("Q 누름");

                if (cooltime == true)
                {
                    Bomb();
                    cooltime = false;
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
    }

    IEnumerator fireBomb()
    {

        //print("a");
        yield return new WaitForSeconds(10.0f); //10초 기다림
        cooltime = true;
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
