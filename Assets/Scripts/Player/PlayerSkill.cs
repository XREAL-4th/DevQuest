using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private SkillManager skillManager;
    [Space]
    [SerializeField] private int skillCode_Q;
    [SerializeField] private bool isCoolTime_Q = false;
    [SerializeField] private int skillCode_E;
    [SerializeField] private bool isCoolTime_E = false;
    [SerializeField] IEnumerator coolDown;

    private void Start()
    {
        //tmp code
        skillCode_Q = 0;
        skillCode_E = 1;
        ///
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)&&!isCoolTime_Q) UseSkill(0, skillCode_Q);
        else if (Input.GetKeyDown(KeyCode.E)&&!isCoolTime_E) UseSkill(1, skillCode_E);
    }

    private void UseSkill(int type, int skillCode) //type = 0 ~ Q, type = 1 ~ E
    {
        float t = skillManager.SkillFuction(skillCode);
        coolDown = CoolDown(type, t);
        StartCoroutine(coolDown);
        Debug.Log("Use skill - Skill code : " + skillCode + " / Cooltime : "+t);
    }

    IEnumerator CoolDown(int type, float t)
    {
        if(type== 0) isCoolTime_Q = true;
        else if(type== 1) isCoolTime_E=true;
        yield return new WaitForSeconds(t);
        if (type == 0) isCoolTime_Q = false;
        else if (type == 1) isCoolTime_E = false;
        Debug.Log("Skill Ready - Skill type : " + type);
        yield break;
    }
}
