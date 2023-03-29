using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGrenade : MonoBehaviour
{
    [SerializeField] private float damage = 30.0f;
    [SerializeField] GameObject grenadeObj; //¼ö·ùÅº ÇÁ¸®ÆÕ
    [SerializeField] GameObject grenadeVfx; //È¿°ú
    [SerializeField] Transform grenadaPoint; //¼ö·ùÅº »ý¼º À§Ä¡
    bool skillAvailable = true;

    IEnumerator coroutine;


    private void Start()
    {
        coroutine = UseSkill();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q) && skillAvailable)
        {
            coroutine = UseSkill();
            StartCoroutine(coroutine);
        }
    }

    public void Grenade()
    {
        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 15, Vector3.up, 0f, LayerMask.GetMask("Enemy"));

        foreach(RaycastHit hitObj in rayHits)
        {
            //hitObj.transform.GetComponent<Enemy>().HitByGrenade(transform.position);
        }

    }

    IEnumerator UseSkill()
    {
        Grenade();

        skillAvailable = false;
        yield return new WaitForSeconds(10f);
        skillAvailable = true;
        yield break;


    }
}
