using System.Collections;
using UnityEngine;

public abstract class StatusEffectItem : Item
{
    public new StatusEffectItemType type;

    protected override void OnGotten(GameObject player)
    {
        if (player.GetComponent<StatusEffectController>() is StatusEffectController shooter) shooter.ApplyStatusEffect(type.effect);
    }
}
