using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public GameObject Bullet;
    public Transform pos;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet,pos.position,transform.rotation);
        }

		

    }
}
