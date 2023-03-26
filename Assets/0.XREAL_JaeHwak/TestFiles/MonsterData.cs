using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "MonsterScriptable/CreateMonsterData",order = int.MaxValue)]
public class MonsterData:ScriptableObject
{
    [SerializeField]
    private float hp;
    public float HP { get { return hp; } set { hp = value; } }


    [SerializeField]
    private string monsterName;
    public string MonsterName { get { return monsterName; } set { monsterName = value; } }

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }
}