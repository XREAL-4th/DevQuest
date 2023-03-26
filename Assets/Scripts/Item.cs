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

	void Start()
    {
		Power = itemData.Power;
}

	public void WatchItemInfo()
	{
		Debug.Log(itemData.ItemType);
		Debug.Log(itemData.Power);
	}

    
    
}