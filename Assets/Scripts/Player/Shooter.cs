using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    public Weapon weapon;
    public float shootDelay = 3;
    private float stateTime = 0;

    private void Update()
    {
        stateTime += Time.deltaTime;
        if (stateTime > shootDelay)
        {
            stateTime = 0;
            if (Input.GetMouseButton(0)) weapon.Shoot();
        }
    }
}
