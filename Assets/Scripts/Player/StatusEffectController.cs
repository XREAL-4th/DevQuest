using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectController : MonoBehaviour
{
    public List<(StatusEffect, float)> statusEffects = new();

    private void Update()
    {
        for(int i = 0; i < statusEffects.Count; i++)
        {
            (StatusEffect effect, ref float duration) = statusEffects[i];
            duration += Time.deltaTime;
            if(duration >= effect.duration)
            {
                statusEffects.RemoveAt(i);
                effect.OnInActive(gameObject);
                continue;
            }
            effect.UpdateStatusEffect(gameObject);
        }
    }

    public void ApplyStatusEffect(StatusEffect effect)
    {
        statusEffects.Add((effect, 0));
        effect.OnActive(gameObject);
    }
}
