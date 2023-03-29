using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "StrenthStatusEffect", menuName = "StatusEffects/StrenthStatusEffect", order = 1)]
public class StrenthStatusEffect : StatusEffect
{
    public float damageMultiplier = 1.5f;


    public override void OnActive(GameObject player)
    {
        if (player.GetComponent<Shooter>() is not Shooter shooter) return;
        shooter.weapon.damagetMultiplier += damageMultiplier;
        Aim.Main.image.sprite = Aim.Main.strenthSprite;
    }

    public override void OnInActive(GameObject player)
    {
        if (player.GetComponent<Shooter>() is not Shooter shooter) return;
        shooter.weapon.damagetMultiplier -= damageMultiplier;
        Aim.Main.image.sprite = Aim.Main.originSprite;
    }
}
