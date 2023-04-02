using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static SkillManager instance;
    private ParticleSystem skillFx;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private MoveControl playerMoveControl;
    [Space]
    [SerializeField] private SkillData[] skills;
    //return Cooltime

    //Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public float SkillFuction(int skillCode)
    {
        switch(skillCode)
        {
            case 0: //Blink
                skillFx = Instantiate(skills[0].skillFx, playerObj.transform);
                skillFx.transform.parent = null;
                playerMoveControl.Blink(skills[0].skillAmount);
                return skills[0].skillCoolTime;
            case 1: //Haste
                IEnumerator tmp = speedBuff(skills[1].skillDuration, skills[1].skillAmount);
                StartCoroutine(tmp);
                return skills[1].skillCoolTime;
            case 2:
                return 10;
            default:
                break;
        }
        return 10;
    }

    IEnumerator speedBuff(float duration, float multi)
    {
        float savedSpeed = playerMoveControl.moveSpeed;
        playerMoveControl.moveSpeed = savedSpeed*multi;
        ParticleSystem buffFx = Instantiate(skills[1].skillFx, playerObj.transform);
        //buffFx.transform.parent = playerObj.transform;
        yield return new WaitForSeconds(duration);
        playerMoveControl.moveSpeed = savedSpeed;
        Destroy(buffFx.gameObject);
        yield break;
    }


    public Sprite UIReturnIcon(int itemCode)
    {
        Debug.Log(itemCode);
        return skills[itemCode].skillIcon;
    }
}
