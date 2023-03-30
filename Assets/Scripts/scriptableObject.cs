using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable/Game Data")]
public class scriptableObject : ScriptableObject
{
    public int coin;
    public float fevertimeDuration;
    public int feverTimeItemNum;
    public int enemyCount;
    public float enemySpeed;
    public float skillCoolTime;
}
