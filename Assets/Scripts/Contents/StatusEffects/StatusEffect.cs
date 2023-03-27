using System.Collections;
using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public float duration = 0;

    public abstract void OnActive(GameObject player);
    public abstract void OnInActive(GameObject player);
    public virtual void UpdateStatusEffect(GameObject player) { }
}
