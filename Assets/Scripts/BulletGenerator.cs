using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject BulletPrefeb;
    public GameObject player;
    private OVRGrabber grabber;

    void Start()
    {
        grabber = GetComponent<OVRGrabber>();
    }
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
            Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            Vector3 shooting = ray.direction;
            shooting = shooting.normalized;

            GameObject bullet = Instantiate(BulletPrefeb) as GameObject;
            bullet.transform.position = Camera.main.transform.position + shooting;
            bullet.GetComponent<BulletController>().Shoot(shooting * 2000);

            Destroy(bullet, 3f);
        }*/
        
        if (OVRInput.GetDown(OVRInput.RawButton.A) /*&& grabber.grabbedObject == this.gameObject*/)
        {

            Vector3 shooting = this.transform.right;
            shooting = shooting.normalized;

            GameObject bullet = Instantiate(BulletPrefeb) as GameObject;
            bullet.transform.position = this.transform.position + shooting;
            bullet.GetComponent<BulletController>().Shoot(shooting * 2000);

            Destroy(bullet, 3f);
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {

            
        }*/
        
    }
}
