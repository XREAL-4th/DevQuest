using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject> ();

    private GameObject effectToSpawn;

    public GameObject spawnPoint;
    private float timeToFire = 0;

    public Grabbable grabbable;
    public GrabInteractable grabbableInteractable;
    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.LHandTrigger))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
                spanwVFX();
                Debug.Log("PrimaryIndexTrigger");
            }
        }
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {

            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
                spanwVFX();
                Debug.Log("SecondaryIndexTrigger");
            }
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            spanwVFX();
        }




/*        if (grab.isGrabbed)
        {

        }*/

/*        if(Input.GetMouseButtonDown(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            spanwVFX();
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            spanwVFX();
            Debug.Log("PrimaryIndexTrigger");
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            spanwVFX();
            Debug.Log("SecondaryIndexTrigger");
        }*/
    }

    void spanwVFX()
    {
        GameObject vfx;

        if(firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            vfx.transform.localRotation = spawnPoint.transform.rotation;
        } else
        {
            Debug.Log("No fire Point");
        }
    }

}
