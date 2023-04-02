using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Skill : MonoBehaviour
{
    [SerializeField]
    private GraphicRaycaster graphicRaycaster;
    [SerializeField]
    private SkillCoolTime[] cooldownTime;

    private List<RaycastResult> raycastResults;
    private PointerEventData pointerEventData;


    private void Awake()
    {
        raycastResults = new List<RaycastResult> { };
        pointerEventData = new PointerEventData(null);
    }

    private void Update()
    {
        //1~9 숫자키를 눌러 스킬 시전
        for (int i = 0; i < cooldownTime.Length; ++ i )
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                cooldownTime[i].StartCooldownTime();
                
            }
        }
    }
    
}
