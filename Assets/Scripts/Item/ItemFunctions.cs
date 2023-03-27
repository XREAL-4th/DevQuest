using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemFunctions : MonoBehaviour
{
    private GameObject player;
    private float rotY;
    [SerializeField] public ItemData itemData;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rotY = 0;
    }

    private void Update()
    {
        rotY += 20 * Time.deltaTime;
        if (rotY > 360) rotY -= 360;
        this.transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        ParticleSystem instance;
        if (other.gameObject == player)
        {
            TakeItem(itemData.itemCode);
            instance = Instantiate(itemData.itemFx, transform.position, Quaternion.identity);
            instance.transform.rotation = Quaternion.Euler(90, 0, 0);
            Destroy(this.gameObject);
        }
    }

    public void TakeItem(int itemCode)
    {
        switch(itemCode)
        {
            case 1:
                player.GetComponent<PlayerShooter>().isPowerShot = true;
                Debug.Log("PowerShot");
                break;
            default:
                break;
        }
    }
}
