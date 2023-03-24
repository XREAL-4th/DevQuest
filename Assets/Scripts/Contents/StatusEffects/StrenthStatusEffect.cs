using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "StrenthStatusEffect", menuName = "StatusEffects/StrenthStatusEffect", order = 1)]
public class StrenthStatusEffect : StatusEffect
{
    public float damageMultiplier = 1.5f;


    public override void OnActive(GameObject player)
    {
        if (player.GetComponent<Shooter>() is Shooter shooter) shooter.damagetMultiplier += damageMultiplier;

    }

    public override void OnInActive(GameObject player)
    {
        if (player.GetComponent<Shooter>() is Shooter shooter) shooter.damagetMultiplier -= damageMultiplier;
    }
}
