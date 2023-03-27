using System.Collections;
using UnityEngine;

public class StatusEffectItem : Item
{
    public StatusEffect effect;

    protected override void OnGotten(GameObject player)
    {
        if (player.GetComponent<StatusEffectController>() is StatusEffectController shooter) 
            shooter.ApplyStatusEffect(effect);
    }
}
