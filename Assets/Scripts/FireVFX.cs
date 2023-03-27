using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireVFX : MonoBehaviour
{
    float time=0;
   
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time>=0.3f){
            Destroy(gameObject);
        }
    }
}
