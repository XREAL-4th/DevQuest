using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     void Update () 
    {
        transform.Translate(Vector3.forward * 1.0f);
    }
}