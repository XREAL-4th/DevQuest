using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "skillScriptable/SkillData", order = int.MaxValue)]
public class SkillData : ScriptableObject
{
    public int skillCode;
    public string skillName;
    [TextArea (3, 5)] public string skillDescription;
    [Space]
    public float skillAmount;
    public float skillCoolTime;
    public float skillDuration;
    public ParticleSystem skillFx;
    public Sprite skillIcon;
}