using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public enum MonsterType { Normal, Tanker, Speeder };
    public List<MonsterData> MonsterDatas = new List<MonsterData>();
    public GameObject monsterPrefab;
    private void Start()
    {
        SpawnMonsterObject();
    }

    public void SpawnMonsterObject()
    {
        for (int i = 0; i < MonsterDatas.Count; i++)
        {
            var monster = SpawnMonsterFunc((MonsterType)i);
            monster.WatchMonsterInfo();
        }
    }

    public Monster SpawnMonsterFunc(MonsterType type)
    {
        float x = Random.Range(-20, 20);
        float y = 2;
        float z = Random.Range(-20, 20);
        Vector3 pos = new Vector3(x, y, z);

        var newMonster = Instantiate(monsterPrefab, pos, Quaternion.identity).GetComponent<Monster>();
        newMonster.MonsterData = MonsterDatas[(int)(type)];

        return newMonster;
    }
}