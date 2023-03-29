using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector3 speed)
    {
        GetComponent<Rigidbody>().AddForce(speed);
    }
}
