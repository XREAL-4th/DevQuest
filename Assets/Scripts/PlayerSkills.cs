using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    
	IEnumerator coroutine;

	public GameObject weaponPrefab;
	public GameObject E_VFX;
	public GameObject R_VFX;
	public Image e_coolTime;
	public Image r_coolTime;
	private bool E_able = true;
	private bool VFX_ableE = false;

	private bool R_able = true;
	private bool VFX_ableR = false;

	void Update()
	{
		if (Input.GetKey(KeyCode.E) && (!PopUpManager.PopUpOn))
		{
			if (E_able)
			{
				VFX_ableE = true;
				E_able = false;
				coroutine = Slice();
				StartCoroutine(coroutine);
			}
            if (VFX_ableE)
            {
				Instantiate(E_VFX, transform);
				VFX_ableE = false;
			}
		}
		if (Input.GetKey(KeyCode.R) && (!PopUpManager.PopUpOn))
        {
			if (R_able)
			{
				VFX_ableR = true;
				R_able = false;
				coroutine = Heal();
				StartCoroutine(coroutine);
			}
			if (VFX_ableR)
			{
				Instantiate(R_VFX, transform);
				VFX_ableR = false;
			}
		}
	}

	IEnumerator Slice()
	{
		yield return StartCoroutine(Skill_E(1f));
		yield return StartCoroutine(Skill_E(2f));
		yield return StartCoroutine(Skill_E(3f));
		yield return StartCoroutine(Skill_E(4f));
		yield return StartCoroutine(Skill_E(5f));
		yield return StartCoroutine(Skill_E(6f));
		yield return StartCoroutine(Skill_E(7f));
		yield return StartCoroutine(Skill_E(8f));
		yield return StartCoroutine(Skill_E(9f));
		

		yield return StartCoroutine(CoolTime(7f,e_coolTime));

		E_able = true;
	}

	IEnumerator Skill_E(float num)
    {
		GameObject weapon = Instantiate(weaponPrefab, transform.position, transform.rotation) as GameObject;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3((Camera.main.pixelWidth * num) / 10, Camera.main.pixelHeight / 2));
		Vector3 shooting = ray.direction;
		shooting = shooting.normalized * 4000;
		weapon.GetComponent<WeaponController>().Launch(shooting);
		yield break;
	}

	IEnumerator Heal()
    {
		PlayerShot.PlayerHp += 15;

		yield return StartCoroutine(CoolTime(15f, r_coolTime));

		R_able = true;
	}

	IEnumerator CoolTime(float cool, Image image)
    {
		float full = cool;
		while (cool > 0f)
		{
			cool -= Time.deltaTime;
			image.fillAmount = 1-(cool/full);
			yield return null;
		}

	}
}
