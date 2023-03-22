using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet; //ÃÑ¾Ë

    public Transform firePos; //ÃÑ¾Ë ¹ß»ç ÁÂÇ¥


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation); //bullet ÇÁ¸®ÆÕ »ý¼º
    }

    
}
