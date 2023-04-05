using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemGet : MonoBehaviour
{
    public GameObject _player;
    [SerializeField] GameObject itemGetVfx;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            SpeedUp();


            collision.gameObject.SetActive(false);


            Debug.Log("ItemDisapear");
        }
    }

    void SpeedUp()
    {
        _player.GetComponent<MoveControl>().moveSpeed += 2.0f;
        Invoke("SpeedDown", 5.0f);
        Debug.Log("SpeedUp");

    }

    void SpeedDown()
    {
        _player.GetComponent<MoveControl>().moveSpeed -= 2.0f;
        Debug.Log("SpeedDown");
    }
        
}
