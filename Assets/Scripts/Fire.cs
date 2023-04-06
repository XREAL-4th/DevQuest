using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;
    public GameObject Hitvfx;
 
    void Update () 
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            //복제한다. //'Bullet'을 'FirePos.transform.position' 위치에 'FirePos.transform.rotation' 회전값으로.
            GameObject bullet = Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            Bulet bulet = bullet.GetComponent<Bulet>();
            bulet.firePos = FirePos;
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
           RaycastHit hit;

          Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
      
        if (Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
        
             Instantiate(Hitvfx,hit.point, Quaternion.identity);

        }
        }
    }
}