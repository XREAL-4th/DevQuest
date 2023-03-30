using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField]
	ItemData itemData;
	public ItemData ItemData { set { itemData = value; } }
	public GameObject player;
	public MoveControl MoveControl;

	bool m_IsPlayer;

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject == player)
			m_IsPlayer = true;
    }

    public void WatchItemInfo()
	{
		Debug.Log(itemData.Name);
		Debug.Log(itemData.Effect);
	}

    private void Update()
    {
		if (m_IsPlayer)
			ItemCalled();
    }

	void ItemCalled()
    {
		if (itemData.Name == "SpeedUp")
			MoveControl.SpeedUp();
		else
			MoveControl.JumpUp();
		Destroy(gameObject);
    }
}
