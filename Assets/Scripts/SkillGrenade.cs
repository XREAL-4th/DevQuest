using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGrenade : MonoBehaviour
{
    [SerializeField] private float damage = 30.0f;
    [SerializeField] GameObject grenadeObj;
    [SerializeField] GameObject grenadeVfx;
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
