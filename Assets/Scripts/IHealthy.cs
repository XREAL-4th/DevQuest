using System.Collections;
using UnityEngine;

interface IHealthy
{
    float Health
    {
        get; set;
    }

    public void Damage(float amount) => Health -= amount;
    public void Heal(float amount) => Health += amount;
}