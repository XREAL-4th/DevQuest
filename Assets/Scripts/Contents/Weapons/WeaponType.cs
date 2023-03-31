using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponType", menuName = "Weapons/WeaponType", order = 1)]

public class WeaponType : ScriptableObject
{
    public float recoilAmount, recoilDownAmount, reloadTime, shootDelay;
    public int ammoPerMaganize;
}