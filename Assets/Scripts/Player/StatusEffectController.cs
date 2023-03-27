using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectController : SingletonMonoBehaviour<StatusEffectController>
{
    public List<(StatusEffect, float)> statusEffects = new();

    private void Update()
    {
        for(int i = 0; i < statusEffects.Count; i++)
        {
            (StatusEffect effect, float duration) = statusEffects[i];
            duration += Time.deltaTime;
            var updatedData = (effect, duration);
            statusEffects[i] = updatedData;
            if(duration >= effect.duration)
            {
                statusEffects.Remove(updatedData);
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
