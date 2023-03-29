using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    public bool SkillAvailable = true;
    public bool OnSkill = false;
    public GameObject[] Enemies = new GameObject[16];
    public GameObject cooltimeUI;
    public GameObject pushVfxPrefab;
    public GameObject player;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (SkillAvailable)
            {
                SkillAvailable = false;

                GameObject vfx = Instantiate(pushVfxPrefab) as GameObject;
                vfx.transform.position = player.transform.position;
                for (int i=0; i<Enemies.Length; i++)
                {
                    Enemies[i].GetComponent<Enemy>().PushSkill();
                    
                }
                StartCoroutine("CoolTime");
            }
        }
    }


    public IEnumerator CoolTime()
    {
        cooltimeUI.SetActive(false);

        yield return new WaitForSeconds(10.0f);

        SkillAvailable = true;
        cooltimeUI.SetActive(true);
    }

}
