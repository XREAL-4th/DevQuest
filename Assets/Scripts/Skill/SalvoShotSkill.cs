using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvoShotSkill : Skill
{
    protected override void Effect()
    {
        Instantiate(activeEffect, Player.Main.shooter.weapon.outTransform.position, Quaternion.identity);
    }

    protected override void OnActive()
    {
        InvokeUtils.RepeatDelay(this, 3, 0.15f, (_) => Player.Main.shooter.weapon.Shoot());
    }
}
