using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public static float timer;
    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime; 

        if(timer > 5f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
