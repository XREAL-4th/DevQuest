using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BulletMovement : MonoBehaviour {
 
    void Update () {
        transform.Translate(Vector3.forward * 1.0f);
    }
}