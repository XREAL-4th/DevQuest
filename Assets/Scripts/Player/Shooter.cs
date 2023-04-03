using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    public Weapon weapon;

    private void Update()
    {
        if (Input.GetMouseButton(0)) weapon.Shoot();
    }
}
