using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
     public float speed =20.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

   /* public void Launch(Vector3 Direction, float Speed)
    {
        GetComponent<Rigidbody>().AddForce(Direction * Speed);
    }*/

}