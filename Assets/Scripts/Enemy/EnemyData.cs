using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable/EnemyData")]

public class EnemyData : ScriptableObject
{
    private string name;
    public int health;
    public float speed;
    public float attackRange;
}
