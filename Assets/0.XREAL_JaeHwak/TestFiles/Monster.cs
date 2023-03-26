using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    MonsterData monsterData;
    public MonsterData MonsterData { set { monsterData = value; } }

    public void WatchMonsterInfo()
    {
        Debug.Log(monsterData.name);
        Debug.Log(monsterData.HP);
        Debug.Log(monsterData.Speed);
    }
}
