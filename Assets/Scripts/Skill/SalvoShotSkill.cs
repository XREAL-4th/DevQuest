using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvoShotSkill : Skill
{
    protected override void Effect()
    {
        Instantiate(activeEffect, Player.Main.shooter.weapon.outTransform.position, Quaternion.identity);
    }

    protected override bool IsAvaliable() => Player.Main.shooter.weapon.IsShootable();

    protected override void OnActive()
    {
        InvokeUtils.RepeatDelay(this, 3, 0.15f, (_) => {
            Player.Main.shooter.weapon.shootTime = 0;
            Player.Main.shooter.weapon.Shoot();
        });
    }
}
