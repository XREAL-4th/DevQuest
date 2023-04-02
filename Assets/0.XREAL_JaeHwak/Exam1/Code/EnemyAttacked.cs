using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyAttacked : MonoBehaviour
{
    public GameObject Enemy_self;
    public Ori_concreteSubject ori_ConcreteSubject;
    public Slider Enemy_health;
    public GameObject Enemy_health_slider;
    public Animator Enemy_ani;
    public GameObject Hit_text;
    private void Start()
    {
        Enemy_health.value = 1f;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);

        if(other.gameObject.name.Contains("VFX_Tutorial"))
        {
            Enemy_ani.Play("Hit_Ani",-1,0f);
            Debug.Log("맞음");
            Enemy_health.value -= 0.35f;
            if(Enemy_health.value <= 0f)
            {
                //처치됨
                Hit_text.transform.SetParent(null, true);
                Enemy_self.SetActive(false);
                Enemy_health.value = 0;
                //Enemy_health_slider.SetActive(false);
                Debug.Log("세번 맞음");
                //ConcreteSubject의 Notify 호출
                ori_ConcreteSubject.Notify();
            }
        }
        
    }
}
