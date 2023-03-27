using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KillEnemiesMission : Mission
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int amounts;

    public override bool IsMissionCompleted()
    {
        int killCount = 0;
        foreach(GameObject gameObject in enemies)
        {
            if (gameObject.IsDestroyed()) killCount++;
            if (killCount >= amounts) return true;
        }
        return false;
    }

    public override bool IsMissionFailed() => false;
}
