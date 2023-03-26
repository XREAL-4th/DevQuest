using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField]
	ItemData itemData;
	public ItemData ItemData { set { itemData = value; } }

	public void WatchItemInfo()
	{
		Debug.Log(itemData.Name);
		Debug.Log(itemData.Power);
		Debug.Log(itemData.Speed);
		Debug.Log(itemData.Score);
	}
}
