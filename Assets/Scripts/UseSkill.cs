using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UseSkill : MonoBehaviour
{
    public bool SkillAvailable = true;
    public bool OnSkill = false;
    public GameObject[] Enemies = new GameObject[16];
    public Image cooltimeImg;
    public GameObject pushVfxPrefab;
    public GameObject player;

    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            if (cooltimeImg.fillAmount >= 1)
            {
                //SkillAvailable = false;

                for (int i = 0; i < Enemies.Length; i++)
                {
                    Enemies[i].GetComponent<Enemy>().PushSkill();
                }
                StartCoroutine(CoolTime(5f));
                SkillAvailable = true;
            }
        }
    }


    public IEnumerator CoolTime(float cool)
    {
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            cooltimeImg.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }
    }
}
