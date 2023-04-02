using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    // Start is called before the first frame update
    GunController PlayerGunCtrl;
    public Image skillFilter;
    public float coolTime;

    private float currentCoolTime;

    private bool canUseSkill = true;
    void Start()
    {
        PlayerGunCtrl = GetComponent<GunController>();
        skillFilter.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseSkill();
        }
    }

    public void UseSkill()
    {
        if (canUseSkill)
        {
            PlayerGunCtrl.MagicShoot();
            Debug.Log("Use Skill");
            skillFilter.fillAmount = 1;
            StartCoroutine("CoolTime");

            currentCoolTime = coolTime;
            StartCoroutine("CoolTimeCounter");

            canUseSkill = false;
        }
        else
        {
            Debug.Log("쿨타임입니다.");
        }
    }
    IEnumerator CoolTime()
    {
        while(skillFilter.fillAmount > 0)
        {
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;

            yield return null;
        }
        canUseSkill = true;
        yield break;
    }

    IEnumerator CoolTimeCounter()
    {
        while(currentCoolTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentCoolTime -= 1.0f;
        }

        yield break;
    }
}
