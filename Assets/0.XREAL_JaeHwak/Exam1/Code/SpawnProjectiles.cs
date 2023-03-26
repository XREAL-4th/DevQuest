using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject> ();

    private GameObject effectToSpawn;

    public GameObject spawnPoint;
    private float timeToFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            spanwVFX();
        }
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
