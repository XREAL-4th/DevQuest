using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //복제한다, Bullet을 FirePos.transform.position위치에 Fire.transform.rotation회전
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation );
        }
    }
}
