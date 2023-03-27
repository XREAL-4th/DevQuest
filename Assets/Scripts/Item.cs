using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField]
	ItemData itemData;


	public float rotateSpeed = 180f;

	public ItemData ItemData { set { itemData = value; } }

	public void WatchItemInfo()
	{
		Debug.Log(itemData.Name);
		Debug.Log(itemData.Power);
		Debug.Log(itemData.Speed);
		Debug.Log(itemData.Score);
	}

    private void Update()
    {
		transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
	}
}
