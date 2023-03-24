using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "Enemies/EnemyType", order = 1)]
public class EnemyType : ScriptableObject
{
    public new string name;
    public float maxHealth;
    public GameObject hitFx;
}
