using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    public Transform firePos;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray,out hit, Mathf.Infinity))
       { 
         Vector3 direction = hit.point-firePos.position;
        transform.Translate(direction.normalized * 0.3f, Space.World);
       }

        
    }
}
