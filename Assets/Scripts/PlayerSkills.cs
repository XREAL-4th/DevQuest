using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    
	IEnumerator coroutine;

	public GameObject weaponPrefab;
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
		yield return StartCoroutine(Shoot(1f));
		yield return StartCoroutine(Shoot(2f));
		yield return StartCoroutine(Shoot(3f));
		yield return StartCoroutine(Shoot(4f));
		yield return StartCoroutine(Shoot(5f));
		yield return StartCoroutine(Shoot(6f));
		yield return StartCoroutine(Shoot(7f));
		yield return StartCoroutine(Shoot(8f));
		yield return StartCoroutine(Shoot(9f));
	}

	IEnumerator Shoot(float num)
    {
		GameObject weapon = Instantiate(weaponPrefab, transform.position, transform.rotation) as GameObject;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3((Camera.main.pixelWidth * num) / 10, Camera.main.pixelHeight / 2));
		Vector3 shooting = ray.direction;
		shooting = shooting.normalized * 4000;
		weapon.GetComponent<WeaponController>().Launch(shooting);
		yield break;
	}
}
