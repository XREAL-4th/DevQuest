using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [Header ("SkillUI")]
    [SerializeField] private Image skillBG_Q;
    [SerializeField] private Image skillIcon_Q;
    [SerializeField] private Image skillBG_E;
    [SerializeField] private Image skillIcon_E;
    [SerializeField] private Color offColorBG;
    [SerializeField] private Color onColorBG;
    [SerializeField] private Color offColorIcon;
    [SerializeField] private Color onColorIcon;
    [Header("Script")]
    [SerializeField] private PlayerSkill playerSkill;
    [SerializeField] private SkillManager skillManager;
    private bool isCoolTime_Q;
    private bool isCoolTime_E;

    // Start is called before the first frame update

    private void ReloadUI(int type = -1)// 0 = Q, 1 = E
    {
        switch(type)
        {
            case 0:
                if(isCoolTime_Q)
                {
                    skillBG_Q.color = offColorBG;
                    skillIcon_Q.color = offColorIcon;
                }
                else
                {
                    skillBG_Q.color = onColorBG;
                    skillIcon_Q.color = onColorIcon;
                }
                break;
            case 1:
                if (isCoolTime_E)
                {
                    skillBG_E.color = offColorBG;
                    skillIcon_E.color = offColorIcon;
                }
                else
                {
                    skillBG_E.color = onColorBG;
                    skillIcon_E.color = onColorIcon;
                }
                break;
            default:
                if (isCoolTime_Q)
                {
                    skillBG_Q.color = offColorBG;
                    skillIcon_Q.color = offColorIcon;
                }
                else
                {
                    skillBG_Q.color = onColorBG;
                    skillIcon_Q.color = onColorIcon;
                }
                if (isCoolTime_E)
                {
                    skillBG_E.color = offColorBG;
                    skillIcon_E.color = offColorIcon;
                }
                else
                {
                    skillBG_E.color = onColorBG;
                    skillIcon_E.color = onColorIcon;
                }
                break;
        }
    }

    public void UpdateUI()
    {
        if (isCoolTime_Q != playerSkill.isCoolTime_Q)
        {
            isCoolTime_Q = playerSkill.isCoolTime_Q;
            ReloadUI(0);
        }
        if (isCoolTime_E != playerSkill.isCoolTime_E)
        {
            isCoolTime_E = playerSkill.isCoolTime_E;
            ReloadUI(1);
        } 
    }

    public void initUI()
    {
        isCoolTime_Q = playerSkill.isCoolTime_Q;
        isCoolTime_E = playerSkill.isCoolTime_E;
        skillIcon_Q.sprite = skillManager.UIReturnIcon(playerSkill.skillCode_Q);
        skillIcon_E.sprite = skillManager.UIReturnIcon(playerSkill.skillCode_E);
        ReloadUI();
    }
}
