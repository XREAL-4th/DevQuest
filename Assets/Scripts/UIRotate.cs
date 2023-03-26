using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotate : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
       
         transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 1000f * Time.deltaTime);
      
    }
}
