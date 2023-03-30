using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField]
	ItemData itemData;
	//public ItemData ItemData { set { itemData = value; } }
	//public GameObject player;
	public int Power;
	public float Freq;
	public float rotateSpeed;


	void Awake()
    {
		Power = itemData.Power;
		Freq = itemData.Freq;
	}

	public void WatchItemInfo()
	{
		Debug.Log(itemData.ItemType);
		Debug.Log(itemData.Power);
	}

	void Update()
    {
		transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
	}

}