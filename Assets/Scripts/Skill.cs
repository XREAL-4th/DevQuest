using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    float cooltime = 5f;
    bool skillAvailable;
    IEnumerator coroutine;
    public GameObject Hitvfx;

    void Start()
    {
        coroutine = CoolTime();
    }

    // Update is called once per frame
    void Update()
    {
        //Q 버튼이 눌렸고 스킬 사용이 가능할 때
        if(Input.GetKeyDown(KeyCode.Q) && skillAvailable)
        {
            //스킬 사용

            RaycastHit hit;

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
      
            if (Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                Instantiate(Hitvfx,hit.point, Quaternion.identity);
            }

            //스킬 쿨타임
            StartCoroutine(coroutine);

        }

        
    }

    IEnumerator CoolTime()
    {
        //쿨타임이 돌 동안 스킬을 사용할 수 없음
        skillAvailable = false;
        yield return new WaitForSeconds(5f); //5초간 중지
        skillAvailable = true;
        yield break;
    }
}
