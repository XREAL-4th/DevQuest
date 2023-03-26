using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject FireVFX;
    public GameObject FireVFX_power;

    //public float speed =20.0f;
    float time = 0;
    float VFXTime = 0;

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector3.forward * Time.deltaTime * speed);

        time += Time.deltaTime;
        VFXTime += Time.deltaTime;

        if(VFXTime>=0.01f){
            if (PowerUp.powerup)
            {
                Instantiate(FireVFX_power, transform.position, transform.rotation);
                VFXTime = 0;
            }
            else
            {
                Instantiate(FireVFX, transform.position, transform.rotation);
                VFXTime = 0;
            }
        }

        if(time>5){
            if (PowerUp.powerup)
            {
                PowerUp.powerup = false;
            }
            Destroy(gameObject);
        }
        
    }

    public void Launch(Vector3 speed)
    {
        GetComponent<Rigidbody>().AddForce(speed);
    }

}