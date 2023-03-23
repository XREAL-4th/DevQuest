using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public void Shoot(Vector3 speed)
    {   
        GetComponent<Rigidbody>().AddForce(speed);
    }
}
