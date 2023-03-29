using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    
	IEnumerator coroutine;

	public GameObject weaponPrefab;
	public Image e_coolTime;

	void Update()
	{
        if (Input.GetKey(KeyCode.E))
        {
			coroutine = Slice();
			StartCoroutine(coroutine);

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

		yield return StartCoroutine(CoolTime(7f));
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

	IEnumerator CoolTime(float cool)
    {
		while (cool > 0f)
		{
			cool -= Time.deltaTime;
			e_coolTime.fillAmount = 1-(cool/7);
			yield return null;
		}

	}
}
