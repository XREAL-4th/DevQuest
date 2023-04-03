using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillGrenade : MonoBehaviour
{
    [SerializeField] GameObject grenadeObj; 
    [SerializeField] GameObject grenadeVfx; 
    [SerializeField] GameObject player;

    [SerializeField] Image fill;
    [SerializeField] float coolTime = 10f; 
    bool skillAvailable = true;


    IEnumerator coroutine;

    private void Start()
    {
        //player = GameManager.Instance.player;
        player = GameObject.Find("Player");
        coroutine = UseSkill();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) && skillAvailable)
        {
            //coroutine = UseSkill();
            StartCoroutine(coroutine);
        }
    }

    public void Grenade()
    {
        Debug.Log("Grenada");

        Collider[] colliders = Physics.OverlapSphere(player.transform.position, 10.0f);
        int damage = 30;


        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].tag == "Enemy")
            {
                Instantiate(grenadeVfx, colliders[i].transform.position, Quaternion.identity);
                colliders[i].gameObject.GetComponent<Enemy>().GetDamage(damage);
            }
        }
    }

    IEnumerator UseSkill()
    {
        Grenade();

        skillAvailable = false;
        //coolDownUI.GetComponent<CoolDownUI>();
        yield return StartCoroutine(CoolTime(coolTime));
        yield return new WaitForFixedUpdate();
        skillAvailable = true;
        yield break;
    }

    IEnumerator CoolTime(float cool) //cool -> 쿨타임 (10f)
    {
        Debug.Log("쿨타임 코루틴 실행");

        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            fill.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("쿨타임 코루틴 완료");

    }

}
