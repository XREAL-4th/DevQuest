using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class QSkill : MonoBehaviour
{
     void Update () 
    {
        transform.Translate(Vector3.forward * 0.5f);
    }
}