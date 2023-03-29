using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    // [SerializeField] public Image imgSkill;
    private static bool waitCool = false;
    public GameObject preFabSkill;
    private static WaitForSeconds waitForSecondsInstance = new WaitForSeconds(5f);
    
    public static Camera cam; // 메인카메라
    
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        UseSkill();
    }

    public void UseSkill() {
        if (!waitCool){
            if(Input.GetKeyDown(KeyCode.T)){
                waitCool = true;
                Ray ray = cam.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit)){
                    GameObject skill = Instantiate(preFabSkill, new Vector3(0f, 0f, 0f), Quaternion.identity);
                    skill.transform.position = hit.point;
                    // print(bullet.layer);
                    Destroy(skill, 1f);
                }
                StartCoroutine(CoolTime(10f));
            }
        }
    }

    IEnumerator CoolTime(float cool){
        Debug.Log("쿨타임 실행");
        yield return waitForSecondsInstance;
        // while (cool > 1.0f){
        //     cool = Time.deltaTime;
        //     imgSkill.fillAmount = (1.0f/cool);
        //     yield return new WaitForFixedUpdate();
        // }
        Debug.Log("쿨타임 완료");
        waitCool = false;
    }
}
